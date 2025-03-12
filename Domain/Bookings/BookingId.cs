using Domain.Primitives;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public record BookingId(Guid Value) : EntityId(Value);
}
