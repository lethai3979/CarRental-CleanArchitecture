using Domain.Abstraction;
using Domain.Bookings;
using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Invoices
{
    public record InvoiceCreatedDomainEvent(Guid Id, Invoice Invoice) : DomainEvent(Id);
}
