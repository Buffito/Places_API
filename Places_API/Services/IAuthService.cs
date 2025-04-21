using Places_API.DTO;

namespace Places_API.Services
{
    public interface IAuthService
    {
        Task<AuthResult> LoginUserAsync(LoginDto loginDto);
        Task<AuthResult> RegisterUserAsync(RegisterDto registerDto);
    }
}
