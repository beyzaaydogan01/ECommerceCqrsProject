﻿
namespace ECommerce.Application.Features.Products.Commands.Create;

public class ProductAddResponseDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public int SubCategoryId { get; set; }
}
