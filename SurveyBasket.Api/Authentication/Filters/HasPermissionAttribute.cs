namespace SurveyBasket.Api.Authentication.Filters;

public class HasPermissionAttribute(string permission) : AuthorizeAttribute(permission)
{
    public string Permission { get; set; } = permission;

}
