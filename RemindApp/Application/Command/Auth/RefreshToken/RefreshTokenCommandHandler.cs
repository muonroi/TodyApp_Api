namespace RemindApp.Application.Command.Auth.RefreshToken;

public class RefreshTokenCommandHandler(IMapper mapper, MAuthenticateInfoContext tokenInfo, IAuthenticateRepository authenticateRepository, ILogger logger, IMediator mediator, MPaginationConfig paginationConfig)
            : BaseCommandHandler(mapper, tokenInfo, authenticateRepository, logger, mediator, paginationConfig),
    IRequestHandler<RefreshTokenCommand, MResponse<RefreshTokenResponseModel>>
{
    public async Task<MResponse<RefreshTokenResponseModel>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        MResponse<RefreshTokenResponseModel> result = new();

        if (string.IsNullOrEmpty(TokenInfo.AccessToken))
        {
            result.AddErrorMessage("InvalidCredentials");
            return result;
        }

        MResponse<string> tokenIsValid = await AuthenticateRepository.ValidateTokenValidity(TokenInfo.TokenValidityKey, cancellationToken).ConfigureAwait(false);

        if (!tokenIsValid.IsOK || string.IsNullOrEmpty(tokenIsValid.Result))
        {
            result.AddErrorMessage("InvalidCredentials");
            return result;
        }

        MResponse<RefreshTokenResponseModel> newToken = await AuthenticateRepository.RefreshToken(new RefreshTokenRequestModel
        {
            AccessToken = TokenInfo.AccessToken,
            RefreshToken = tokenIsValid.Result
        }, cancellationToken).ConfigureAwait(false);

        if (!newToken.IsOK)
        {
            result.AddErrorMessage("InvalidCredentials");
            return result;
        }

        result.Result = newToken.Result;

        return result;
    }
}
