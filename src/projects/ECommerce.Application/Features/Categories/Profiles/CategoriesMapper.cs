
using AutoMapper;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Domain.Entities;

namespace ECommerce.Application.Features.Categories.Profiles;

public class CategoriesMapper : Profile
{
    public CategoriesMapper()
    {
        CreateMap<Category, CategoryAddCommand>().ReverseMap();
        CreateMap<Category, CategoryAddedResponseDto>().ReverseMap();
    }
}
