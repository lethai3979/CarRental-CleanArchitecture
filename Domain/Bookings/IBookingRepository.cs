using Domain.Abstraction;
using Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public interface IBookingRepository : IGenericRepository<Booking, BookingId>
    {
        Task<List<Booking>> GetAllByUserId(string userId);
    }
}
