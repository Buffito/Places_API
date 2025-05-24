using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Places_API.Data;
using Places_API.DTO.Place;
using Places_API.Models;

namespace Places_API.Services.Place
{
    public class PlaceService : IPlaceService
    {
        private readonly PlacesDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlaceService(PlacesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<PlaceDto> CreatePlaceAsync(CreatePlaceDto createPlaceDto)
        {
            var place = _mapper.Map<Models.Place>(createPlaceDto);
            _dbContext.Places.Add(place);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PlaceDto>(place);
        }

        public async Task<PlaceDto> GetPlaceByIdAsync(int id)
        {
            var place = await _dbContext.Places.FindAsync(id);
            return place == null ? null : _mapper.Map<PlaceDto>(place);
        }

        public async Task<IEnumerable<PlaceDto>> GetAllPlacesAsync()
        {
            var places = await _dbContext.Places.ToListAsync();
            return _mapper.Map<IEnumerable<PlaceDto>>(places);
        }

        public async Task<PlaceDto> UpdatePlaceAsync(int id, UpdatePlaceDto updatePlaceDto)
        {
            var place = await _dbContext.Places.FindAsync(id);
            if (place == null) return null;

            _mapper.Map(updatePlaceDto, place);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<PlaceDto>(place);
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

        public async Task<bool> UpdateStarRatingAsync(int id, int starRating)
        {
            if (starRating < 1 || starRating > 5)
                return false;

            var place = await _dbContext.Places.FindAsync(id);
            if (place == null)
                return false;

            place.StarRating = starRating;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}