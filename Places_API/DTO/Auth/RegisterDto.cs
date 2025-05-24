using System.ComponentModel.DataAnnotations;

namespace Places_API.DTO.Auth
{
    public class RegisterDto
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}