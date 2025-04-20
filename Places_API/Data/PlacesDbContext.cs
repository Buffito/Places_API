using Microsoft.EntityFrameworkCore;
using Places_API.Models;

namespace Places_API.Data
{
    public class PlacesDbContext : DbContext
    {
        public PlacesDbContext(DbContextOptions<PlacesDbContext> options) : base(options)
        {
        }
        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Place>().ToTable("Places");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
