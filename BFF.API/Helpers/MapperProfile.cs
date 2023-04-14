using AutoMapper;
using BFF.API.Models.DTOs.Product;
using BFF.Models.Entities;

namespace BFF.API.Helpers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductInsertDto, Product>().ReverseMap();
            CreateMap<ProductUpdateDto, Product>().ReverseMap();
        }
    }
}
