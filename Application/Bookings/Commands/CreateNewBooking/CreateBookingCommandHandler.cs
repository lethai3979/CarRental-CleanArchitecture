using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Promotions;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Commands.CreateNewBooking
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
                var promotion = await _unitOfWork.PromotionRepository.GetById(request.PromotionId);
                if (promotion == null)
                {
                    return Result.FailureResult(Error.NotFound("Promotion not found"));
                }

                if (!promotion.IsActive())
                {
                    return Result.FailureResult(Error.BadRequest("Promotion deactivate"));
                }

                //Calculate booking total price
                var car = await _unitOfWork.CarRepository.GetById(request.CarId);
                if (car == null) 
                {
                    return Result.FailureResult(Error.NotFound("Car not found"));
                }
                var totalPrice = (decimal)(request.ReturnDate - request.RecieveDate).TotalDays * car.Price;

                var booking = Booking.Create
                (
                    new BookingId(Guid.NewGuid()),
                    totalPrice,
                    request.RecieveDate,
                    request.ReturnDate,
                    request.CarId,
                    request.UserId!,
                    request.PromotionId
                );
                await _unitOfWork.BookingRepository.Add(booking);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
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
