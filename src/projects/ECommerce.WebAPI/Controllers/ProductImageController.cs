using Core.Application.Requests;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using ECommerce.Application.Features.ProductImages.Commands.Create;
using ECommerce.Application.Features.ProductImages.Queries.GetList;
using ECommerce.Application.Features.ProductImages.Queries.GetListByPaginate;
using ECommerce.Application.Features.ProductImages.Queries.GetListByProductd;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> UploadImage(ProductImageAddCommand command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var response = await Mediator.Send(new GetListProductImageQuery());
            return Ok(response);
        }

        [HttpGet("paginate")]
        public async Task<IActionResult> GetALlPaginate([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListProductImageByPaginateQuery
            {
                PageRequest = pageRequest
            });
            return Ok(response);
        }

        [HttpGet("getallbyproductId")]
        public async Task<IActionResult> GetAllImagesByProductId([FromQuery] Guid id)
        {
            var response = await Mediator.Send(new GetListByProductIdQuery
            {
                ProductId = id
            });

            return Ok(response);
        }
    }
}
