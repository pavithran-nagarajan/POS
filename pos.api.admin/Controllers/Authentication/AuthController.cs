using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using pos.application.DTOs.AuthToken;
using pos.application.Interfaces.AuthToken;

namespace pos.api.admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var loginResult = await ValidateLoginAsync(request);
            if (loginResult is null)
                return Unauthorized("Invalid credentials.");

            var tokenRequest = new UserTokenRequestDto
            {
                UserId = loginResult.UserId,
                UserGuid = loginResult.UserGuid,
                UserRole = loginResult.UserRole
            };

            var tokens = await _tokenService.GenerateTokensAsync(tokenRequest);
            return Ok(tokens);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh([FromBody] RefreshRequestDto request)
        {
            try
            {
                var tokens = await _tokenService.RefreshTokenAsync(request.RefreshToken);
                return Ok(tokens);
            }
            catch (SecurityTokenException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        private Task<UserTokenRequestDto> ValidateLoginAsync(LoginRequestDto request)
        {
            var result = new UserTokenRequestDto
            {
                UserId = 1,
                UserGuid = Guid.NewGuid(),
                UserRole = "SUPER"
            };

            return Task.FromResult(result);
        }
    }

    public class LoginRequestDto
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class RefreshRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }
}