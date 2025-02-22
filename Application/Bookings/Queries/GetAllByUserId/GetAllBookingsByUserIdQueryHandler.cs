using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Bookings;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings.Queries.GetAllByUserId
{
    internal sealed class GetAllBookingsByUserIdQueryHandler : IQueryHandler<GetAllBookingsByUserIdQuery, Result<List<Booking>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBookingsByUserIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Booking>>> Handle(GetAllBookingsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var bookings = await _unitOfWork.BookingRepository.GetAllByUserId(request.UserId);
            return Result<List<Booking>>.SuccessResult(bookings);
        }
    }
}
