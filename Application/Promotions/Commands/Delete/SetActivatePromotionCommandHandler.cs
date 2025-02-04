using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.Delete
{
    internal sealed class SetActivatePromotionCommandHandler : ICommandHandler<SetActivatePromotionCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        public SetActivatePromotionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(SetActivatePromotionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var promotion = await _unitOfWork.PromotionRepository.GetById(request.Id);
                if (promotion == null)
                {
                    return Result.FailureResult(Error.NotFound("Promotion not found"));
                }
                promotion.IsDeleted = request.IsDelete;
                _unitOfWork.PromotionRepository.Update(promotion);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
            {
                return Result.FailureResult(Error.OperationFailed(dbEx.Message));
            }
        }
    }
}
