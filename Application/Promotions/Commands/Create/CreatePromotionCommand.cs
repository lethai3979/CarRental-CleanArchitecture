using Application.Abstraction;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.Create
{
    public sealed record CreatePromotionCommand : ICommand<Result>
    {
        public required string Name { get; set; }
        public required double Discount { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime ExpireDate { get; set; }
    }
}
