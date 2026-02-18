namespace SurveyBasket.Api.Contracts.Authentication;

public class RefreshTokenRequestValidatorcs : AbstractValidator<RefreshTokenRequest>
{
    public RefreshTokenRequestValidatorcs()
    {

        RuleFor(x => x.Token)
            .NotEmpty();

        RuleFor(x=> x.RefreshToken)
            .NotEmpty();

    }

}
