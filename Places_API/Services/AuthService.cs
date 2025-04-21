using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Places_API.Data;
using Places_API.DTO;
using Places_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Places_API.Services
{
    public class AuthService
    {
        private readonly PlacesDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(PlacesDbContext dbContext, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            this._passwordHasher = passwordHasher;
        }

        public async Task<AuthResult> RegisterUserAsync(RegisterDto registerDto)
        {
            if (registerDto.Password != registerDto.ConfirmPassword)
                return new AuthResult { Success = false, Message = "Passwords do not match" };

            if (await _dbContext.Users.AnyAsync(u => u.Username == registerDto.Username))
                return new AuthResult { Success = false, Message = "Username already exists" };

            var user = new User
            {
                Username = registerDto.Username,
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, registerDto.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            var token = GenerateJwtToken(user);
            return new AuthResult { Success = true, Token = token };
        }

        public async Task<AuthResult> LoginUserAsync(LoginDto loginDto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == loginDto.Username);
            if (user == null)
                return new AuthResult { Success = false, Message = "Invalid username or password" };
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, loginDto.Password);
            if (result == PasswordVerificationResult.Failed)
                return new AuthResult { Success = false, Message = "Invalid username or password" };
            var token = GenerateJwtToken(user);
            return new AuthResult { Success = true, Token = token };
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", user.Id.ToString()),
                    new System.Security.Claims.Claim("username", user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(key),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
