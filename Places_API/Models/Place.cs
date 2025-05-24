using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Places_API.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        [Required, StringLength(200)]
        public string Address { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Url]
        public string GoogleMapsUrl { get; set; }

        public bool Visited { get; set; }

        [Range(1, 5)]
        public int StarRating { get; set; }
    }
}