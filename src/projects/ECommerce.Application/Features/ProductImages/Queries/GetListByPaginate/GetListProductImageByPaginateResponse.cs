﻿
namespace ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;

public record struct GetListProductImageByPaginateResponse
{
    public int Id { get; init; }
    public string Url { get; init; }
    public Guid ProductId { get; init; }
    public string ProductName { get; init; }
}