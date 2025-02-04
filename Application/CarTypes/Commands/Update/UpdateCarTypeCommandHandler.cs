using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Commands.Update
{
    internal sealed class UpdateCarTypeCommandHandler : ICommandHandler<UpdateCarTypeCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateCarTypeCommand request, CancellationToken cancellationToken)
        {
            if (request.Name == null)
            {
                return Result.FailureResult(Error.BadRequest("Name is required"));
            }
            var carType = await _unitOfWork.CarTypeRepository.GetById(request.Id);
            if (carType == null)
            {
                return Result.FailureResult(Error.NotFound("Car type not found"));
            }
            carType.Name = request.Name;
            await _unitOfWork.SaveChangesAsync();
            return Result.SuccessResult();
        }
    }
}
