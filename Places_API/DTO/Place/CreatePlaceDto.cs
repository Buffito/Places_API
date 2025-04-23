namespace Places_API.DTO.Place
{
    public class CreatePlaceDto
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string GoogleMapsUrl { get; set; }
    }
}
