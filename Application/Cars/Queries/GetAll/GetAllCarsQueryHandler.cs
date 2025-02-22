using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Cars;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Queries.GetAll
{
    internal sealed class GetAllCarsQueryHandler : IQueryHandler<GetAllCarsQuery, Result<List<Car>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Car>>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _unitOfWork.CarRepository.GetAll();
            return Result<List<Car>>.SuccessResult(cars);
        }
    }
}
