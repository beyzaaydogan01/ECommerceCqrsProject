
using AutoMapper;
using Core.Persistence.Extensions;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{
    public CategoriesMapper()
    {
        CreateMap<Category, CategoryAddCommand>().ReverseMap();
        CreateMap<Category, CategoryAddedResponseDto>().ReverseMap();

        CreateMap<Category, GetListCategoryResponseDto>().ReverseMap();

        CreateMap<Category, GetByIdCategoryResponseDto>().ReverseMap();

        CreateMap<Category, GetListByPaginateCategoryResponseDto>().ReverseMap();
        CreateMap<Paginate<Category>, Paginate<GetListByPaginateCategoryResponseDto>>().ReverseMap();
    }
}
