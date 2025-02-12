using Domain.Bookings;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices
{
    public class Invoice : BaseEntity<InvoiceId>
    {
        private Invoice(InvoiceId id,DateTime createDate, decimal total, BookingId bookingId) : base(id)
        {
            CreateDate = createDate;
            Total = total;
            BookingId = bookingId;
        }

        public DateTime CreateDate { get; private set; }
        public decimal Total { get; private set; }
        public BookingId BookingId { get; private set; }
        public Booking Booking { get; private set; } = null!;

        public static Invoice Create(DateTime createDate, decimal total, BookingId bookingId)
        {
            if (createDate != DateTime.Now)
            {
                throw new InvalidDataException("Create date invalid");
            }
            if (total <= 0)
            {
                throw new InvalidDataException("Total value invalid");
            }
            if(bookingId == null)
            {
                throw new InvalidDataException("booking id is null");
            }
            var invoice = new Invoice(new InvoiceId(Guid.NewGuid()), createDate, total, bookingId);
            invoice.Raise(new InvoiceCreatedDomainEvent(Guid.NewGuid(), invoice));
            return invoice;
        }
    }
}
