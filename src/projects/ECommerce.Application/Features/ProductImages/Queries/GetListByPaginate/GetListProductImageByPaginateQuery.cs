
using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Requests;
using Core.Persistence.Extensions;
using Core.Persistence.Repositories;
using ECommerce.Application.Services.Repositories;
using MediatR;

namespace ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;

public class GetListProductImageByPaginateQuery : IRequest<Paginate<GetListProductImageByPaginateResponse>>
    , ICachableRequest
{
    public PageRequest PageRequest { get; set; }

    public string CacheKey => $"GetListProductImage({PageRequest.PageIndex}, {PageRequest.PageSize})";
    public bool ByPassCache => false;

    //3.sayfada 5 tane veri
    //4.sayfada 10 tane veri
    //GetListProductImage(3,5)
    //GetListProductImage(4,10)
    public string? CacheGroupKey => "ProductImages";
    public TimeSpan? SlidingExpiration { get; }

    public class GetListProductImageByPaginateQueryHandler : IRequestHandler
        <GetListProductImageByPaginateQuery, Paginate<GetListProductImageByPaginateResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IProductImageRepository _productImageRepository;

        public GetListProductImageByPaginateQueryHandler(IMapper mapper, IProductImageRepository productImageRepository)
        {
            _mapper = mapper;
            _productImageRepository = productImageRepository;
        }

        public async Task<Paginate<GetListProductImageByPaginateResponse>> Handle(GetListProductImageByPaginateQuery request, CancellationToken cancellationToken)
        {
            var images = await _productImageRepository.GetPaginateAsync(
                index:request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken);

            var response = _mapper.Map<Paginate<GetListProductImageByPaginateResponse>>(images);

            return response;
        }
    }
}
