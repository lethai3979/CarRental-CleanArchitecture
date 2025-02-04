using Application.Abstraction.Commands;
using Application.UnitOfWork;
using AutoMapper;
using Domain.Shared;

namespace Application.Cars.Commands.Update
{
    internal sealed class UpdateCarCommandHandler : ICommandHandler<UpdateCarCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _unitOfWork.CarRepository.GetById(request.Id);
                if (car == null)
                {
                    return Result.FailureResult(Error.NotFound("Car not found"));
                }
                car.Update(request.Name, request.Seats, request.Price, request.CarTypeId, request.CompanyId);
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
