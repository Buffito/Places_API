using Places_API.DTO.Place;

namespace Places_API.Services.Place
{
    public interface IPlaceService
    {
        Task<PlaceDto> CreatePlaceAsync(CreatePlaceDto createPlaceDto);
        Task<PlaceDto> GetPlaceByIdAsync(int id);
        Task<IEnumerable<PlaceDto>> GetAllPlacesAsync();
        Task<PlaceDto> UpdatePlaceAsync(int id, UpdatePlaceDto updatePlaceDto);
        Task<bool> DeletePlaceAsync(int id);
        Task<bool> MarkVisitedAsync(int id);
        Task<bool> MarkUnvisitedAsync(int id);
    }
}
