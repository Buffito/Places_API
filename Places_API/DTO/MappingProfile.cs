using AutoMapper;
using Places_API.DTO.Category;
using Places_API.DTO.Place;
using Places_API.Models;

namespace Places_API.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Place, PlaceDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
            CreateMap<CreatePlaceDto, Models.Place>();
            CreateMap<UpdatePlaceDto, Models.Place>();
            CreateMap<Models.Place, CreatePlaceDto>();
            CreateMap<Models.Place, UpdatePlaceDto>();

            CreateMap<Models.Category, CategoryDto>();
            CreateMap<CreateCategoryDto, Models.Category>();
            CreateMap<CategoryDto, Models.Category>();
        }
    }
}