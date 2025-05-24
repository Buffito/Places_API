using System.ComponentModel.DataAnnotations;

namespace Places_API.DTO.Category
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Url]
        public string? IconUrl { get; set; }
    }
}