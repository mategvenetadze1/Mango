using AutoMapper;
using Mango.Services.ProductAPI.Models.Dtos;
using Mango.Services.ProductAPI.Models.Entities;

namespace Mango.Services.ProductAPI;

public class Mapper
{
    public static MapperConfiguration Register()
    {
        return new MapperConfiguration(config => 
        {
            config.CreateMap<Product, ProductDto>().ReverseMap();
        });
    }
}
