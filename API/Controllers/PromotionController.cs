using API.Extensions;
using Application.Promotions.Commands.Create;
using Application.Promotions.Queries.GetAll;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PromotionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllPromotionQuery();
            var result = await _mediator.Send(request);
            return Results.Ok(result.Data);
        }

        [Authorize(Roles = Role.Admin)]
        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreatePromotionCommand command)
        { 
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok("Success") : result.ToProblemDetails();
        }
    }
}
