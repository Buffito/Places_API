using AutoMapper;
using Places_API.DTO.Category;
using Places_API.DTO.Place;

namespace Places_API.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Place, PlaceDto>().ReverseMap();
            CreateMap<Models.Place, CreatePlaceDto>().ReverseMap();
            CreateMap<Models.Place, UpdatePlaceDto>().ReverseMap();

            CreateMap<Models.Category, CategoryDto>().ReverseMap();
            CreateMap<Models.Category, CreateCategoryDto>().ReverseMap();
        }
    }
}
