namespace RemindApp.Application.Command.Auth.Register;

public class RegisterCommand : RegisterRequestModel, IRequest<MResponse<LoginResponseModel>>
{
}
