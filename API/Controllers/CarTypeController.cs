using Application.CarTypes.Commands.Add;
using Application.CarTypes.Queries.GetAll;
using Domain.CarTypes;
using Domain.Shared;
using MediatR;
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

        [HttpGet]
        public async Task<ActionResult<List<CarType>>> GetAll()
        {
            var request = new GetAllCarTypesQuery();
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Result>> Add(CreateCarTypeCommand request)
        {
            await _mediator.Send(request);

            return Ok();
        }
    }
}
