using Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class BookingRepository : GenericRepository<Booking, BookingId>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        } 
    }
}
