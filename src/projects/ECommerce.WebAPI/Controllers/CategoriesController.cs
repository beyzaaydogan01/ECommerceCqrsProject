using ECommerce.Application.Features.Categories.Commands.Create;
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
}
