using Application.Abstraction.Commands;
using Application.Abstraction.Services;
using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.CancelBooking
{
    internal class CancelBookingCommandHandler : ICommandHandler<CancelBookingCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInvoiceService _invoiceService;

        public CancelBookingCommandHandler(IUnitOfWork unitOfWork, IInvoiceService invoiceService)
        {
            _unitOfWork = unitOfWork;
            _invoiceService = invoiceService;
        }

        public async Task<Result> Handle(CancelBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = await _unitOfWork.BookingRepository.GetById(request.BookingId);
                if (booking == null)
                {
                    return Result.FailureResult(Error.NotFound("Booking not found"));
                }
                if (booking.Status != BookingStatus.Ongoing)
                {
                    booking.UpdateStatus(BookingStatus.Cancelled);
                }
                else
                {
                    booking.UpdateStatus(BookingStatus.Refunded);
                    var refundResult = await _invoiceService.CancelByBooking(booking);
                    if (!refundResult.Success)
                    {
                        return refundResult;                        
                    }
                }
                _unitOfWork.BookingRepository.Update(booking);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch(DbUpdateException dbEx)
            {
                return Result.FailureResult(Error.OperationFailed(dbEx.Message));
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.BadRequest(ex.Message));
            }
        }
    }
}
