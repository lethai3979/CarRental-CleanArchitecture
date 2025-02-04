using Domain.Bookings;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public interface IBookingRepository : IGenericRepository<Booking, BookingId>
    {
    }
}
