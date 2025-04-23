using Microsoft.AspNetCore.Mvc;
using Places_API.DTO.Place;
using Places_API.Services.Place;

namespace Places_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _placeService.GetAllPlacesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _placeService.GetPlaceByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlaceDto dto)
        {
            var created = await _placeService.CreatePlaceAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdatePlaceDto dto)
        {
            var updatedPlace = await _placeService.UpdatePlaceAsync(id, dto);
            return updatedPlace == null ? NotFound() : Ok(updatedPlace);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) =>
            await _placeService.DeletePlaceAsync(id) ? NoContent() : NotFound();

        [HttpPatch("{id}/visit")]
        public async Task<IActionResult> Visit(int id) =>
            await _placeService.MarkVisitedAsync(id) ? NoContent() : NotFound();

        [HttpPatch("{id}/unvisit")]
        public async Task<IActionResult> Unvisit(int id) =>
            await _placeService.MarkUnvisitedAsync(id) ? NoContent() : NotFound();
    }
}
