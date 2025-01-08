
using AutoMapper;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Commands.Update;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Products.Profiles;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<ProductAddCommand, Product>().ReverseMap();
        CreateMap<Product, ProductAddResponseDto>().ReverseMap();

        CreateMap<Product, ProductUpdateCommand>().ReverseMap();
        CreateMap<ProductUpdateResponseDto, Product>().ReverseMap();


        CreateMap<Product, GetListProductResponseDto>().ForMember(
            p => p.CategoryName,
            opt => opt.MapFrom(x=>x.SubCategory.Name));
    }
}
