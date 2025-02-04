using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Bookings
{
    public enum BookingStatus
    {
        Pending,
        Ongoing,
        Confirmed,
        RequestCancelled,
        Cancelled
    }
}
