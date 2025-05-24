using Microsoft.AspNetCore.Mvc;
using Places_API.DTO.Category;
using Places_API.Services.Category;

namespace Places_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll() =>
            Ok(await _categoryService.GetAllCategoriesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> Get(int id)
        {
            var result = await _categoryService.GetCategoryByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CategoryDto>> Create([FromBody] CreateCategoryDto dto)
        {
            var created = await _categoryService.CreateCategoryAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }
    }
}