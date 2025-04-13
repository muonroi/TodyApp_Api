namespace RemindApp.Application.Command.Auth.Login;

public class LoginCommand : IRequest<MResponse<LoginResponseModel>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
