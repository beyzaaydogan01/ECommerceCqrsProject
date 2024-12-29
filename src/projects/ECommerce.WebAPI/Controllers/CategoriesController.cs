using Core.Application.Requests;
using ECommerce.Application.Features.Categories.Commands.Create;
using ECommerce.Application.Features.Categories.Commands.Delete;
using ECommerce.Application.Features.Categories.Queries.GetById;
using ECommerce.Application.Features.Categories.Queries.GetList;
using ECommerce.Application.Features.Categories.Queries.GetListByPaginate;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CategoryAddCommand categoryAddCommand)
    {
        CategoryAddedResponseDto response = await Mediator.Send(categoryAddCommand);
        return Ok(response);
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        GetListCategoryQuery query = new GetListCategoryQuery();

        List<GetListCategoryResponseDto> responses = await Mediator.Send(query);

        return Ok(responses);
    }

    [HttpGet("paginate")]
    public async Task<IActionResult> GetPaginate([FromQuery] PageRequest pageRequest)
    {
        var query = new GetListByPaginateCategoryQuery { PageRequest = pageRequest };
        var response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromQuery] int id) =>
         Ok(await Mediator.Send(new GetByIdCategoryQuery { Id = id }));

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var command = new DeleteCategoryCommand { Id = id };
        await Mediator.Send(command);

        return Ok(command);
    }
}
