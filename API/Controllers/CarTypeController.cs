using API.Extensions;
using Application.CarTypes.Commands.Add;
using Application.CarTypes.Queries;
using Application.CarTypes.Queries.GetAll;
using Domain.CarTypes;
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
    public class CarTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllCarTypesQuery();
            var result = await _mediator.Send(request);

            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IResult> GetById(string id)
        {
            var request = new GetByIdCarTypeQuery(new CarTypeId(new Guid(id)));
            var result = await _mediator.Send(request);

            return result.Success ? Results.Ok(result.Data) : result.ToProblemDetails();
        }

        [Authorize(Roles = Role.Admin)]

        [HttpPost("Add")]
        public async Task<IResult> Add(CreateCarTypeCommand request)
        {
            var result = await _mediator.Send(request);

            return result.Success ? Results.Ok() : result.ToProblemDetails();
        }
    }
}
