using Domain.Bookings;
using Domain.Shared;

namespace Application.Abstraction.Services
{
    public interface IInvoiceService
    {
        Task<Result> CancelByBooking(Booking booking);
    }
}
