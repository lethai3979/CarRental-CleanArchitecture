using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.CarTypes;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Queries.GetById
{
    internal sealed class GetByIdCarTypeHandler : IQueryHandler<GetByIdCarTypeQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdCarTypeHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetByIdCarTypeQuery request, CancellationToken cancellationToken)
        {
            var carType = await _unitOfWork.CarTypeRepository.GetById(request.Id);
            if (carType == null)
            {
                return Result<CarType>.FailureResult(Error.NotFound("Car type not found"));
            }
            return Result<CarType>.SuccessResult(carType);
        }
    }
}
