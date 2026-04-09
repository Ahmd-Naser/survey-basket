namespace SurveyBasket.Api.Contracts.Authentication;

public record ConfirmedEmailRequest(
    string UserId,
    string Code
);