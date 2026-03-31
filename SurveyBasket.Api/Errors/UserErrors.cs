namespace SurveyBasket.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new( "User.InvalidCredentials","Invalid username Or password" , StatusCodes.Status401Unauthorized );

    public static readonly Error InvalidJwtToken =
    new("User.InvalidJwtToken", "Invalid Token", StatusCodes.Status401Unauthorized);

    public static readonly Error InvalidRefreshToken =
    new("User.InvalidRefreshToken", "Operation Failed", StatusCodes.Status401Unauthorized);

}
