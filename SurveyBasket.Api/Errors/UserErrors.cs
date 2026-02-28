namespace SurveyBasket.Api.Errors;

public static class UserErrors
{
    public static readonly Error InvalidCredentials =
        new( "User.InvalidCredentials","Invalid username Or password" );

    public static readonly Error InvalidJwtToken =
    new("User.InvalidJwtToken", "Invalid Token");

    public static readonly Error InvalidRefreshToken =
    new("User.InvalidRefreshToken", "Operation Failed");

}
