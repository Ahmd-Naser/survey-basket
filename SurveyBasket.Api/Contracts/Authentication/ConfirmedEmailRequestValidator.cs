namespace SurveyBasket.Api.Contracts.Authentication;

public class ConfirmedEmailRequestValidator : AbstractValidator<ConfirmedEmailRequest >
{
    public ConfirmedEmailRequestValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();
         
        RuleFor(x => x.Code)
            .NotEmpty();

    }

}
