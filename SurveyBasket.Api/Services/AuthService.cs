using Microsoft.AspNetCore.Identity;
using SurveyBasket.Api.Authentication;

namespace SurveyBasket.Api.Services;

public class AuthService(UserManager<ApplicationUser> useManager , IJwtProvider jwtProvider) : IAuthService
{
    private readonly UserManager<ApplicationUser> _useManager = useManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<AuthResponse?> GetTokenAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var user = await _useManager.FindByEmailAsync(email);

        if (user == null)
            return null;

        var isValidPassword = await _useManager.CheckPasswordAsync(user, password);

        if (!isValidPassword)
            return null;

        // generate JWT token

        var (token, expiresIn) = _jwtProvider.GenerateToken(user);
        return new AuthResponse(user.Id , user.Email , user.FirstName! , user.LastName! , token , expiresIn );
    }
}
