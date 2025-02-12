using Application.Abstraction;
using Domain.Bookings;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Commands.Create
{
    public sealed record CreateInvoiceCommand : ICommand<Result>
    {
        public required BookingId BookingId {  get; set; }
        public required decimal Total {  get; set; }
    }
}
