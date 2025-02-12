using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Invoices;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Invoices.Commands.Create
{
    internal sealed class CreateInvoiceCommandHandler : ICommandHandler<CreateInvoiceCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateInvoiceCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var booking = await _unitOfWork.BookingRepository.GetById(request.BookingId);
            if(booking == null)
            {
                return Result.FailureResult(Error.NotFound("Booking not found"));
            }    
            if(booking.TotalPrice != request.Total)
            {
                return Result.FailureResult(Error.InvalidData("Total price invalid"));
            }
            var invoice = Invoice.Create(DateTime.Now, request.Total, request.BookingId);
            await _unitOfWork.InvoiceRepository.Add(invoice);
            await _unitOfWork.SaveChangesAsync();
            return Result.SuccessResult();
        }
    }
}
