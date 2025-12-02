using Application.Abstraction.Services;
using Domain.Bookings;
using Domain.Invoices;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Result> CancelByBooking(Booking booking)
        {
            var invoice = await _invoiceRepository.GetByBookingId(booking.Id);
            if (invoice == null)
            {
                return Result.FailureResult(Error.NotFound("Invoice not found"));
            }
            invoice.IsDeleted = true;
            try
            {
                _invoiceRepository.Update(invoice);
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
            {
                return Result.FailureResult(Error.BadRequest(dbEx.Message));
            }
        }
    }
}
