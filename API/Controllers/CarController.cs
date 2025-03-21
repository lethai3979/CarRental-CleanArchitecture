using API.Extensions;
using Application.Cars.Commands.Create;
using Application.Cars.Commands.SetDelete;
using Application.Cars.Commands.Update;
using Application.Cars.Queries.GetAll;
using Application.Cars.Queries.GetById;
using Application.CarTypes.Queries;
using Domain.Cars;
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

        [HttpGet("GetById/{id}")]
        public async Task<IResult> GetById(string id)
        {
            if (Guid.TryParse(id, out _) == false)
            {
                return Results.BadRequest("Invalid car id");
            }
            var request = new GetCarByIdQuery(new CarId(new Guid(id)));
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

        [Authorize(Roles = Role.Admin)]
        [HttpPut("Update/{id}")]
        public async Task<IResult> Update(string id,[FromBody] UpdateCarCommand command)
        {
            if (Guid.TryParse(id, out _) == false)
            {
                return Results.BadRequest("Invalid car id");
            }
            command.Id = new CarId(new Guid(id));
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpDelete("Delete/{id}")]
        public async Task<IResult> Delete(string id)
        {
            if (Guid.TryParse(id, out _) == false)
            {
                return Results.BadRequest("Invalid car id");
            }
            var command = new DeleteCarCommand(new CarId(new Guid(id)));
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }
    }
}
