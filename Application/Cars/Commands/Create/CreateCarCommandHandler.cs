using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Cars;
using Domain.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Commands.Create
{
    internal sealed class CreateCarCommandHandler : ICommandHandler<CreateCarCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var car = Car.Create(request.Name, request.Seats, request.Price, request.CarTypeId, request.CompanyId);
                await _unitOfWork.CarRepository.Add(car);
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
