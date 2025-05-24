using System.ComponentModel.DataAnnotations;

namespace Places_API.DTO.Auth
{
    public class LoginDto
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }
    }
}