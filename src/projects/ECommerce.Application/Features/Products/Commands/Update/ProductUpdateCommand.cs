
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Constants;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Rules;
using ECommerce.Application.Services.Repositories;
using ECommerce.Domain.Entities;
using MediatR;

namespace ECommerce.Application.Features.Products.Commands.Update;

public class ProductUpdateCommand : IRequest<ProductUpdateResponseDto>, ISecuredRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }
    public string[] Roles => [GeneralOperationClaims.Admin];

    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, ProductUpdateResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly ProductBusinessRules _businessRules;

        public ProductUpdateCommandHandler(IProductRepository productRepository, IMapper mapper, ProductBusinessRules businessRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<ProductUpdateResponseDto> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);

            var created = await _productRepository.UpdateAsync(product);

            var response = _mapper.Map<ProductUpdateResponseDto>(created);

            return response;
        }
    }
}
