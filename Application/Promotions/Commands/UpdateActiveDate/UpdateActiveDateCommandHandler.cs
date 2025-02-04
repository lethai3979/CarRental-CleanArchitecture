using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.UpdateActiveDate
{
    internal sealed class UpdateActiveDateCommandHandler : ICommandHandler<UpdateActiveDateCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateActiveDateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateActiveDateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var promotion = await _unitOfWork.PromotionRepository.GetById(request.Id);
                if (promotion == null)
                {
                    return Result.FailureResult(Error.NotFound("Promotion not found"));
                }
                promotion.UpdateActiveDate(request.StartDate, request.EndDate);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch(DbUpdateException dbEx)
            {
                return Result.FailureResult(Error.OperationFailed(dbEx.Message));
            }
            catch (Exception ex)
            {
                return Result.FailureResult(Error.BadRequest(ex.Message));
            }
        }
    }
}
