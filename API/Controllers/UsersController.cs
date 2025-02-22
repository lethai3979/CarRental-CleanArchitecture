using API.Extensions;
using Application.Users.Commands.Login;
using Application.Users.Commands.Register;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }

        [HttpPost("Login")]
        public async Task<IResult> Login(LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result.Data) : result.ToProblemDetails();
        }
    }
}
