using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands
{
    internal sealed class CreateBookingCommandHandler : ICommandHandler<CreateBookingCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBookingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var booking = Booking.Create
                (
                    new BookingId(Guid.NewGuid()),
                    request.TotalPrice,
                    request.RecieveDate,
                    request.ReturnDate,
                    request.CarId,
                    request.UserId,
                    request.PromotionId
                );
                await _unitOfWork.BookingRepository.Add(booking);
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
