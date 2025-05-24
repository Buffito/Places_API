using System.ComponentModel.DataAnnotations;

namespace Places_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }
}