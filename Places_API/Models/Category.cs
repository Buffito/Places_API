namespace Places_API.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? IconUrl { get; set; }
        public List<Place> Places { get; set; } = new List<Place>();
    }
}
