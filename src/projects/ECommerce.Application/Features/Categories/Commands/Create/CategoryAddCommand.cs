
using AutoMapper;
using Core.Application.Pipelines.Login;
using Core.Application.Pipelines.Performance;
using ECommerce.Application.Features.Categories.Rules;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public sealed class CategoryAddCommand:IRequest<CategoryAddedResponseDto>, ILoginRequest
{
    public string Name { get; set; }

    public sealed class CategoryAddCommandHandler(
        IMapper _mapper, ICategoryRepository _categoryRepository, CategoryBusinessRules _businessRules)

        : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {

        public async Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CategoryNameMustBeUniqueAsync(request.Name, cancellationToken);

            Category? category = _mapper.Map<Category>(request);

            await _categoryRepository.AddAsync(category);

            CategoryAddedResponseDto response = _mapper.Map<CategoryAddedResponseDto>(category);

            return response;
        }
    }
}
