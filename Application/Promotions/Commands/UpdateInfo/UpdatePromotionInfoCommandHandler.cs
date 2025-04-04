﻿using Application.Abstraction.Commands;
using Application.UnitOfWork;
using Domain.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.UpdateInfo
{
    internal class UpdatePromotionInfoCommandHandler : ICommandHandler<UpdatePromotionInfoCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePromotionInfoCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdatePromotionInfoCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var promotion = await _unitOfWork.PromotionRepository.GetById(request.Id);
                if (promotion == null)
                {
                    return Result.FailureResult(Error.NotFound("Promotion not found"));
                }

                promotion.UpdateInfomation(request.Content, request.DiscountValue);
                _unitOfWork.PromotionRepository.Update(promotion);
                await _unitOfWork.SaveChangesAsync();
                return Result.SuccessResult();
            }
            catch (DbUpdateException dbEx)
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
