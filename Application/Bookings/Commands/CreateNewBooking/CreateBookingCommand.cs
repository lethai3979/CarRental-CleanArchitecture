using Application.Abstraction;
using Domain.Bookings;
using Domain.Cars;
using Domain.Promotions;
using Domain.Shared;
using Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.CreateNewBooking
{
    public sealed record CreateBookingCommand : ICommand<Result>
    {
        public decimal TotalPrice { get; set; }
        public DateTime RecieveDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public BookingStatus Status { get; set; }
        public required CarId CarId { get; set; }
        public required PromotionId PromotionId { get; set; }
        public required string UserId { get; set; }

    }
}
