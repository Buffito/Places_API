namespace Places_API.DTO.Place
{
    public class PlaceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string GoogleMapsUrl { get; set; }
        public bool Visited { get; set; }
        public int StarRating { get; set; }
    }
}