using System.ComponentModel.DataAnnotations;

namespace Places_API.DTO.Place
{
    public class UpdatePlaceDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Url]
        public string GoogleMapsUrl { get; set; }

        public bool Visited { get; set; }

        [Range(1, 5, ErrorMessage = "Star rating must be between 1 and 5.")]
        public int StarRating { get; set; }
    }
}