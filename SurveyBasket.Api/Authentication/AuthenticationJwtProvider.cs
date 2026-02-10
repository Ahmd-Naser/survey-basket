
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SurveyBasket.Api.Authentication;

public class JwtProvider : IJwtProvider
{
    public (string token, int expiresIn) GenerateToken(ApplicationUser user)
    {
        Claim[] claims = [
            new(JwtRegisteredClaimNames.Sub , user.Id),
            new(JwtRegisteredClaimNames.Email , user.Email),
            new(JwtRegisteredClaimNames.GivenName , user.FirstName!),
            new(JwtRegisteredClaimNames.FamilyName , user.LastName!),
            new(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
            
        ];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("zTVCikSPcjTWN3jV9T3vMr2s7Lxp4sk1"));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey ,SecurityAlgorithms.HmacSha256);

        var expiresIn = 30;

        var token = new JwtSecurityToken(
            issuer: "SurveyBasketApp",
            audience: "SurveyBasketApp Users",
            claims:claims,
            expires: DateTime.UtcNow.AddMinutes(expiresIn),
            signingCredentials: signingCredentials

        );

        return (token: new JwtSecurityTokenHandler().WriteToken(token) , expiresIn: expiresIn);

    }
}
