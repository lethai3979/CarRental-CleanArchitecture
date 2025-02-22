using Application.Abstraction.Queries;
using Domain.Bookings;
using Domain.Shared;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetAllByUserId
{
    public sealed record GetAllBookingsByUserIdQuery(string UserId) : IQuery<Result<List<Booking>>>;
}
