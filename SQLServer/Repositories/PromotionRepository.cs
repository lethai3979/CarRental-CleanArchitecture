using Domain.Promotions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class PromotionRepository : GenericRepository<Promotion, PromotionId>, IPromotionRepository
    {
        public PromotionRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
