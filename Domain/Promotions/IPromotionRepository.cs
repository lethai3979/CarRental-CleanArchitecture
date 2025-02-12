using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Promotions
{
    public interface IPromotionRepository : IGenericRepository<Promotion, PromotionId>
    {

    }
}
