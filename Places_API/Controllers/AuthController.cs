using Microsoft.AspNetCore.Mvc;
using Places_API.DTO;
using Places_API.Services;

namespace Places_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var result = await _authService.LoginUserAsync(loginDto);
            if (!result.Success) return Unauthorized(result.Message);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var result = await _authService.RegisterUserAsync(registerDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

    }
}
