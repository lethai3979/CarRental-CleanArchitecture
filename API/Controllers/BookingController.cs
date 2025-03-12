using API.Extensions;
using Application.Bookings.Commands.CreateNewBooking;
using Application.Bookings.Queries.GetAllByUserId;
using Domain.Shared;
using Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
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

        public BookingController(IMediator mediator, IHttpContextAccessor contextAccessor)
        {
            _mediator = mediator;
            _contextAccessor = contextAccessor;
            _userId = _contextAccessor.HttpContext?.User
                     .FindFirstValue(ClaimTypes.NameIdentifier) ?? "UnknownUser"; ;
        }

        [Authorize]
        [HttpGet("GetAllPersonalBookings")]
        public async Task<IResult> GetAll()
        {
            var request = new GetAllBookingsByUserIdQuery(_userId);
            var result = await _mediator.Send(request);
            return result.Success ? Results.Ok(result.Data) : result.ToProblemDetails();
        }

        [Authorize]
        [HttpPost("Add")]
        public async Task<IResult> Add([FromBody] CreateBookingCommand command)
        {
            command.UserId = _userId;
            var result = await _mediator.Send(command);
            return result.Success ? Results.Ok(result) : result.ToProblemDetails();
        }
    }
}
