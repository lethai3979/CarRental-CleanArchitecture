using Application.Abstraction.Queries;
using Application.UnitOfWork;
using Domain.Promotions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Queries.GetAll
{
    internal class GetAllPromotionQueryHandler : IQueryHandler<GetAllPromotionQuery, Result<List<Promotion>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPromotionQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<Promotion>>> Handle(GetAllPromotionQuery request, CancellationToken cancellationToken)
        {
            var promotions = await _unitOfWork.PromotionRepository.GetAll();
            return Result<List<Promotion>>.SuccessResult(promotions);
        }
    }
}
