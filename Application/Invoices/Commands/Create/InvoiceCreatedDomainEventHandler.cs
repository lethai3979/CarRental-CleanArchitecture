using Application.UnitOfWork;
using Domain.Invoices;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Commands.Create
{
    internal sealed class InvoiceCreatedDomainEventHandler : INotificationHandler<InvoiceCreatedDomainEvent>
    {
        private readonly IUnitOfWork _unitOfWork;
        public InvoiceCreatedDomainEventHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(InvoiceCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetById(notification.Invoice.BookingId);
            if (booking == null)
            {
                throw new InvalidOperationException("Booking not found");
            }
            booking.ApplyInvoice(notification.Invoice);
            _unitOfWork.BookingRepository.Update(booking);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
