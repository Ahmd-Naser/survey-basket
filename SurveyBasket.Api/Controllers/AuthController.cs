using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;

        [HttpPost("")]
        public async Task<IActionResult> LoginAsync(LoginRequest request , CancellationToken cancellationToken = default)
        {
            var authResult = await _authService.GetTokenAsync(request.Email , request.Password , cancellationToken);  

            return authResult is null ? BadRequest("Invalid email/password "): Ok(authResult);
        }

    }
}
