namespace RemindApp.Application.Command.CreateTodoList;

public class CreateTodoListCommandHandler(
    IMapper mapper,
    MAuthenticateInfoContext tokenInfo,
    IAuthenticateRepository authenticateRepository,
    ILogger logger,
    IMediator mediator,
    MPaginationConfig paginationConfig,
    ITodoListRepository todoTaskRepository
) : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<CreateTodoListCommand, MResponse<bool>>
{
    public async Task<MResponse<bool>> Handle(CreateTodoListCommand request, CancellationToken cancellationToken)
    {
        MResponse<bool> result = new();

        // --- XỬ LÝ DATETIME ---
        DateTime? utcDueDate = null; // Biến để lưu giá trị UTC
        if (request.DueDate.HasValue)
        {
            DateTime dateValue = request.DueDate.Value;
            // Nếu Kind là Local hoặc không xác định (Unspecified), chuyển đổi sang UTC
            // Lỗi đã chỉ rõ là Local nên chỉ cần kiểm tra Local hoặc dùng ToUniversalTime()
            if (dateValue.Kind == DateTimeKind.Local)
            {
                utcDueDate = dateValue.ToUniversalTime();
            }
            else if (dateValue.Kind == DateTimeKind.Unspecified)
            {
                // Nếu là Unspecified, cần quyết định xem nó đại diện cho Local hay UTC.
                // Giả định là Local và chuyển sang UTC là an toàn nhất nếu không chắc chắn.
                // Hoặc nếu bạn chắc chắn nó là UTC thì gán trực tiếp.
                // utcDueDate = DateTime.SpecifyKind(dateValue, DateTimeKind.Utc); // Nếu chắc là UTC
                utcDueDate = TimeZoneInfo.ConvertTimeToUtc(dateValue, TimeZoneInfo.Local); // Giả định là Local
            }
            else // Nếu đã là Utc thì giữ nguyên
            {
                utcDueDate = dateValue;
            }
        }

        // --- XỬ LÝ TIMESPAN (NẾU VẪN DÙNG CÁCH 1) ---
        TimeSpan? parsedReminderTime = request.ReminderTime; // Giữ nguyên nếu backend model là TimeSpan?
                                                             // Nếu bạn đổi backend model thành string? thì cần parse ở đây (xem câu trả lời trước)

        // --- KIỂM TRA VÀ SỬA LỖI KHÁC ---
        // Lỗi 1: Priority - Model request là int, code đang parse enum -> Sửa lại
        // Giả sử TodoListEntity.Priority là kiểu PriorityLevel? (enum)
        PriorityLevel? entityPriority = null;
        if (request.Priority >= 0 && request.Priority < PriorityLevel.GetValues(typeof(PriorityLevel)).Length) // Kiểm tra index hợp lệ
        {
            entityPriority = (PriorityLevel)request.Priority; // Ép kiểu trực tiếp từ int
        }
        // Lỗi 2: Category - Model request là string, code đang parse Guid -> Sửa lại (chọn 1 trong 2 phương án ở câu trả lời trước)
        Guid? entityCategoryId = null;
        // Phương án A: Nếu request.Category CHỨA Guid string hợp lệ
        // if (Guid.TryParse(request.Category, out var parsedGuid)) { entityCategoryId = parsedGuid; }
        // Phương án B: Nếu request.Category là ID dạng khác ("3") và cần tìm Guid từ DB
        // entityCategoryId = await FindCategoryGuidFromStringAsync(request.Category); // Cần hàm này

        // Tạm thời giả sử bạn đã sửa Category thành Guid? trong request và Flutter gửi Guid string
        if (Guid.TryParse(request.Category, out Guid parsedGuid))
        {
            entityCategoryId = parsedGuid;
        }


        TodoListEntity newTodoTask = new()
        {
            Name = request.Name,
            Description = request.Description,
            DueDate = utcDueDate, // <<< Gán giá trị UTC đã chuyển đổi
            IsDone = request.IsDone,
            HasReminder = request.HasReminder,
            ReminderTime = parsedReminderTime, // <<< Gán TimeSpan? đã parse (nếu cần)
            ReminderRepeats = request.ReminderRepeats,
            Priority = entityPriority, // <<< Gán Priority đã xử lý
            CategoryId = entityCategoryId, // <<< Gán CategoryId đã xử lý
        };

        todoTaskRepository.Add(newTodoTask);
        await todoTaskRepository.UnitOfWork.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        result.Result = true;


        return result;
    }
}
