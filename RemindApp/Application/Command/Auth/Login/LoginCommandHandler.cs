

namespace RemindApp.Application.Command.Auth.Login;

public class LoginCommandHandler(
    IAuthenticateRepository authenticateRepository
    )
    : IRequestHandler<LoginCommand, MResponse<LoginResponseModel>>
{
    public async Task<MResponse<LoginResponseModel>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        MResponse<LoginResponseModel> result = new();
        MResponse<LoginResponseModel> authResult = await authenticateRepository.Login(new LoginRequestModel
        {
            Username = request.Username,
            Password = request.Password
        }, cancellationToken).ConfigureAwait(false);

        if (!authResult.IsOK)
        {
            result.AddErrorMessage("Tài khoản hoặc mật khẩu không hợp lệ");
            return result;
        }

        return authResult;
    }
}
