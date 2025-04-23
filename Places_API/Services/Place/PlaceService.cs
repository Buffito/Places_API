using Microsoft.EntityFrameworkCore;
using Places_API.Data;
using Places_API.DTO.Place;

namespace Places_API.Services.Place
{
    public class PlaceService : IPlaceService
    {
        private readonly PlacesDbContext _dbContext;
        public PlaceService(PlacesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PlaceDto> CreatePlaceAsync(CreatePlaceDto createPlaceDto)
        {
            var place = new Models.Place
            {
                Name = createPlaceDto.Name,
                Category = createPlaceDto.Category,
                Address = createPlaceDto.Address,
                Description = createPlaceDto.Description,
                GoogleMapsUrl = createPlaceDto.GoogleMapsUrl,
                Visited = false
            };
            _dbContext.Places.Add(place);
            await _dbContext.SaveChangesAsync();
            return new PlaceDto
            {
                Id = place.Id,
                Name = place.Name,
                Category = place.Category,
                Address = place.Address,
                Description = place.Description,
                GoogleMapsUrl = place.GoogleMapsUrl,
                Visited = place.Visited
            };
        }

        public async Task<PlaceDto> GetPlaceByIdAsync(int id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return null;
            return new PlaceDto
            {
                Id = place.Id,
                Name = place.Name,
                Category = place.Category,
                Address = place.Address,
                Description = place.Description,
                GoogleMapsUrl = place.GoogleMapsUrl,
                Visited = place.Visited
            };
        }

        public async Task<IEnumerable<PlaceDto>> GetAllPlacesAsync()
        {
            var places = await _dbContext.Places.ToListAsync();
            return places.Select(p => new PlaceDto
            {
                Id = p.Id,
                Name = p.Name,
                Category = p.Category,
                Address = p.Address,
                Description = p.Description,
                GoogleMapsUrl = p.GoogleMapsUrl,
                Visited = p.Visited
            });
        }

        public async Task<PlaceDto> UpdatePlaceAsync(int id, UpdatePlaceDto updatePlaceDto)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return null;
            place.Name = updatePlaceDto.Name;
            place.Category = updatePlaceDto.Category;
            place.Address = updatePlaceDto.Address;
            place.Description = updatePlaceDto.Description;
            place.GoogleMapsUrl = updatePlaceDto.GoogleMapsUrl;
            await _dbContext.SaveChangesAsync();
            return new PlaceDto
            {
                Id = place.Id,
                Name = place.Name,
                Category = place.Category,
                Address = place.Address,
                Description = place.Description,
                GoogleMapsUrl = place.GoogleMapsUrl,
                Visited = place.Visited
            };
        }

        public async Task<bool> DeletePlaceAsync(int id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return false;
            _dbContext.Places.Remove(place);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkVisitedAsync(int id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return false;
            place.Visited = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> MarkUnvisitedAsync(int id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return false;
            place.Visited = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}