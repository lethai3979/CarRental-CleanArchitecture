using Application.Abstraction.Queries;
using Domain.Promotions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Queries.GetAll
{
    public sealed record GetAllPromotionQuery : IQuery<Result<List<Promotion>>>
    {
    }
}
 