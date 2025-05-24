using Places_API.DTO.Auth;

namespace Places_API.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResult> LoginUserAsync(LoginDto loginDto);
        Task<AuthResult> RegisterUserAsync(RegisterDto registerDto);
    }
}