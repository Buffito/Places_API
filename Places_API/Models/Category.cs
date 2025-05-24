using System.ComponentModel.DataAnnotations;

namespace Places_API.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Url]
        public string? IconUrl { get; set; }

        public List<Place> Places { get; set; } = new();
    }
}