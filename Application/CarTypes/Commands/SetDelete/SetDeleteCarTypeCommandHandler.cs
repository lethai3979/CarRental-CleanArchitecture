using Application.Abstraction.Commands;
using Application.CarTypes.Commands.Delete;
using Application.UnitOfWork;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Commands.SetDelete
{
    internal sealed class SetDeleteCarTypeCommandHandler : ICommandHandler<SetDeleteCarTypeCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SetDeleteCarTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(SetDeleteCarTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Disabling all cars that belong to the car type
                var carList = await _unitOfWork.CarRepository.GetAll();
                carList.Where(c => c.CarTypeId == request.CarTypeId)
                    .ToList()
                    .ForEach(car =>
                    {
                        car.IsDeleted = request.IsDeleted;
                    });

                var carType = await _unitOfWork.CarTypeRepository.GetById(request.CarTypeId);
                if (carType == null)
                {
                    return Result.FailureResult(Error.NotFound("Car type not found"));
                }
                carType.IsDeleted = request.IsDeleted;
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.OperationFailed(ex.Message));

            }
        }
    }
}
