using AutoMapper;
using Core.Persistence.Extensions;
using ECommerce.Application.Features.ProductImages.Commands.Create;
using ECommerce.Application.Features.ProductImages.Queries.GetList;
using ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;
using ECommerce.Application.Features.ProductImages.Queries.GetListByProductd;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.ProductImages.Profiles;

public class ProductImageProfile : Profile
{
    public ProductImageProfile()
    {
        CreateMap<ProductImageAddCommand, ProductImage>();
        CreateMap<ProductImage, ProductImageAddedResponseDto>();
        CreateMap<ProductImage, GetListProductImageResponse>();
        CreateMap<ProductImage, GetListProductImageByPaginateResponse>();
        CreateMap<Paginate<ProductImage>, Paginate<GetListProductImageByPaginateResponse>>();
        CreateMap<ProductImage, GetListByProductIdResponse>();
    }
}
