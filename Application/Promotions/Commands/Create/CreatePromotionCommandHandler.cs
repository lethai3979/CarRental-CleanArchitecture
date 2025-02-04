using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Promotions;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.Create
{
    internal sealed class CreatePromotionCommandHandler : ICommandHandler<CreatePromotionCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePromotionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreatePromotionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var promotion = Promotion.Create
                (
                    new PromotionId(Guid.NewGuid()),
                    request.Name,
                    request.Discount,
                    request.StartDate,
                    request.ExpireDate
                );

                await _unitOfWork.PromotionRepository.Add(promotion);
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
