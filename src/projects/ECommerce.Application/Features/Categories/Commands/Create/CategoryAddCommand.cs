
using AutoMapper;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Categories.Commands.Create;

public class CategoryAddCommand:IRequest<CategoryAddedResponseDto>
{
    public string Name { get; set; }

    public class CategoryAddCommandHandler : IRequestHandler<CategoryAddCommand, CategoryAddedResponseDto>
    {
        private readonly IMapper _mapper;

        public CategoryAddCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Task<CategoryAddedResponseDto> Handle(CategoryAddCommand request, CancellationToken cancellationToken)
        {
            Category? category = _mapper.Map<Category>(request);
            category.CreatedDate = DateTime.UtcNow;

            CategoryAddedResponseDto response = _mapper.Map<CategoryAddedResponseDto>(category);

            return Task.FromResult(response);
        }
    }
}
