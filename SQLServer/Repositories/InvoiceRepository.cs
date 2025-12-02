using Domain.Bookings;
using Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class InvoiceRepository : GenericRepository<Invoice, InvoiceId>, IInvoiceRepository
    {
        public InvoiceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Invoice?> GetByBookingId(BookingId bookingId)
        {
            return await context.Invoices.FirstOrDefaultAsync(i => i.BookingId == bookingId && !i.IsDeleted);
        }
    }
}
