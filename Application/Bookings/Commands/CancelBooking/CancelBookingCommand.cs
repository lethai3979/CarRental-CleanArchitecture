﻿using Application.Abstraction;
using Domain.Bookings;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Application.Bookings.Commands.CancelBooking
{
    internal class CancelBookingCommand : ICommand<Result>
    {
        public required BookingId BookingId { get; set; }
    }
}
