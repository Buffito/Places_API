using Places_API.DTO.Category;

namespace Places_API.DTO.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; } = null!;
        public string Address { get; set; }
        public string Description { get; set; }
        public string GoogleMapsUrl { get; set; }
        public bool Visited { get; set; }
    }
}
