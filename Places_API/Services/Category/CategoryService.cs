using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Places_API.Data;
using Places_API.DTO.Category;
using Places_API.Models;

namespace Places_API.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly PlacesDbContext _dbContext;
        private readonly IMapper _mapper;

        public CategoryService(PlacesDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Models.Category>(createCategoryDto);
            _dbContext.Categories.Add(category);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category == null ? null : _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories.ToListAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }
    }
}