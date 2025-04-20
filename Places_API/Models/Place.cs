﻿namespace Places_API.Models
{
    public class Place
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        //public string GoogleMapsUrl { get; set; }
        public bool Visited { get; set; }
    }
}
