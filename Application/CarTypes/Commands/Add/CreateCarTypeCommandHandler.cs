using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.CarTypes;
using Domain.Shared;
using MediatR;

namespace Application.CarTypes.Commands.Add
{
    internal sealed class CreateCarTypeCommandHandler : ICommandHandler<CreateCarTypeCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCarTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Name))
                {
                    return Result.FailureResult(Error.InvalidData("Name is required"));
                }
                var carType = new CarType(new CarTypeId(Guid.NewGuid()), request.Name);
                await _unitOfWork.CarTypeRepository.Add(carType);
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
