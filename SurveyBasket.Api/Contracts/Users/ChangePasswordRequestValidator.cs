using SurveyBasket.Api.Abstractions.Consts;

namespace SurveyBasket.Api.Contracts.Users;

public class ChangePasswordRequestValidator: AbstractValidator<ChangePasswordRequest>
{
    public ChangePasswordRequestValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty();    
        
        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .Matches(RegexPatterns.Password)
            .WithMessage("Current password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one special character.")
            .NotEqual(x=> x.CurrentPassword)
            .WithMessage("New password cannot be the same as current password");
    }
}
