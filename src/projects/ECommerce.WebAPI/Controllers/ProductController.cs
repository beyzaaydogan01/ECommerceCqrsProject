using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Products.Commands.Create;
using ECommerce.Application.Features.Products.Commands.Delete;
using ECommerce.Application.Features.Products.Queries.GetList;
using ECommerce.Application.Features.Products.Queries.GetListByElasticSearch;
using ECommerce.Application.Features.Products.Queries.GetListByImages;
using ECommerce.Application.Features.Products.Queries.GetListFilterByElasticSearch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add(ProductAddCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            List<GetListProductResponseDto> responses = await Mediator.Send(new GetListProductQuery());
            return Ok(responses);   
        }

        [HttpGet("getallbyImages")]
        public async Task<IActionResult> GetAllByImageUrls()
        {
            List<GetListProductByProductImagesResponse> responses = await Mediator.Send(new GetListProductByProductImageQuery());
            return Ok(responses);
        }

        [HttpGet("getallbyElasticSearch")]
        public async Task<IActionResult> GetAllElasticSearch()
        {
            var response = await Mediator.Send(new GetProductListElasticSearchQuery());
            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> GetAllByFilter([FromQuery] string text)
        {
            var query = new GetProductListFilterByElasticSearchQuery() { Text = text };

            var response = await Mediator.Send(query);

            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery]Guid id)
        {
            var command = new ProductDeleteCommand() {  Id = id };

            var response = await Mediator.Send(command);

            return Ok(response);
        }
    }
}
