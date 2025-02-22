using API.Extensions;
using Application.Bookings.Commands.CreateNewBooking;
using Application.Bookings.Queries.GetAllByUserId;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly string _userId;

        public BookingController(IMediator mediator, IHttpContextAccessor contextAccessor, string userId)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext?.User
                     .FindFirstValue(JwtRegisteredClaimNames.Sub) ?? "UnknownUser"; ;
        }

        [HttpGet("GetAll")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllBookingsByUserIdQuery(_userId);
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result.Data) : result.ToProblemDetails();
        }

        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreateBookingCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }
    }
}
