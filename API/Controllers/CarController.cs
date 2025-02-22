using API.Extensions;
using Application.Cars.Commands.Create;
using Application.Cars.Queries.GetAll;
using Domain.Shared;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllCarsQuery(); 
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result.Data) : result.ToProblemDetails();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreateCarCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }
    }
}
