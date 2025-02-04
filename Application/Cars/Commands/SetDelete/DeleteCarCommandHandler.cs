using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Commands.SetDelete
{
    internal sealed class DeleteCarCommandHandler : ICommandHandler<DeleteCarCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _unitOfWork.CarRepository.GetById(request.Id);
                if (car == null)
                {
                    return Result.FailureResult(Error.NotFound("Car not found"));
                }
                car.IsDeleted = request.IsDeleted;
                _unitOfWork.CarRepository.Update(car);
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
