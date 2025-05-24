using Microsoft.EntityFrameworkCore;
using Places_API.Models;

namespace Places_API.Data
{
    public class PlacesDbContext : DbContext
    {
        public PlacesDbContext(DbContextOptions<PlacesDbContext> options) : base(options) { }

        public DbSet<Place> Places { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>().ToTable("Places");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Category>().ToTable("Categories");

            modelBuilder.Entity<Place>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Places)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Place>()
                .Property(p => p.StarRating)
                .HasDefaultValue(1);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}