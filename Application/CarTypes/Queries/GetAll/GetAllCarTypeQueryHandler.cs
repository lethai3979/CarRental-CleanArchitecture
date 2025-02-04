using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Queries.GetAll
{
    internal sealed class GetAllCarTypeQueryHandler : IQueryHandler<GetAllCarTypesQuery, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarTypeQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(GetAllCarTypesQuery request, CancellationToken cancellationToken)
        {
            var carTypes = await _unitOfWork.CarTypeRepository.GetAll();
            return Result<List<CarType>>.SuccessResult(carTypes);
        }
    }
}
