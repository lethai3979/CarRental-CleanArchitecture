using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public enum BookingStatus
    {
        Pending, // Booking is created but not yet confirmed
        Ongoing, // Confirmed and payment is received
        Confirmed, // Booking is confirmed, not yet paid
        Cancelled,
        Refunded, 
    }
}
