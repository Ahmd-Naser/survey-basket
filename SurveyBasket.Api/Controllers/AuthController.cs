using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SurveyBasket.Api.Abstractions;
using SurveyBasket.Api.Authentication;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService ) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
 
        [HttpPost("")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request , CancellationToken cancellationToken = default)
        {
            var authResult = await _authService.GetTokenAsync(request.Email , request.Password , cancellationToken);

            return authResult.IsSuccess
                ? Ok(authResult.Value)
                : authResult.ToProblem(StatusCodes.Status400BadRequest);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshAsync([FromBody]  RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            var authResult = await _authService.GetRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);


            return authResult.IsSuccess 
                ? Ok(authResult.Value)
                : authResult.ToProblem(StatusCodes.Status404NotFound);



        }
        [HttpPost("revoke-refresh-token")]
        public async Task<IActionResult> RevokeRefreshTokenAsync([FromBody] RefreshTokenRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _authService.RevokeRefreshTokenAsync(request.Token, request.RefreshToken, cancellationToken);


            return result.IsSuccess 
                ? Ok()
                : result.ToProblem(StatusCodes.Status404NotFound);

        }


    }
}
