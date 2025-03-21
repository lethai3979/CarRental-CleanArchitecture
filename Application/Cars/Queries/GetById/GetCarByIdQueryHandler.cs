using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Cars;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Queries.GetById
{
    internal sealed class GetCarByIdQueryHandler : IQueryHandler<GetCarByIdQuery, Result<Car>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Car>> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetById(request.Id);
            if(car == null)
            {
                return Result<Car>.FailureResult(Error.NotFound("Car not found"));
            }
            return Result<Car>.SuccessResult(car);
        }
    }
}
