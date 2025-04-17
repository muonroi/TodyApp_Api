



namespace RemindApp.Application.Command.Auth.Register;

public class RegisterCommandHandler(
    IAuthService<Permission, RemindAppDbContext> authService
    )
    : IRequestHandler<RegisterCommand, MResponse<LoginResponseModel>>
{
    public async Task<MResponse<LoginResponseModel>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        MResponse<LoginResponseModel> result = await authService.RegisterAsync(new RegisterRequestModel
        {
            UserName = request.UserName,
            Password = request.Password,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            Name = request.Name,
            Surname = request.Surname
        }, cancellationToken).ConfigureAwait(false);

        return result;
    }
}
