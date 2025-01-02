using Core.Security.Dtos;
using ECommerce.Application.Features.Auth.Commands.AuthLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginForUser(UserForLoginDto dto)
        {
            var response = await Mediator.Send(new Login.Command(dto));
            return Ok(response);
        }
    }
}
