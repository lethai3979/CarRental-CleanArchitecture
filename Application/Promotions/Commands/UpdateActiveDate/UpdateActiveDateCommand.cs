using Application.Abstraction;
using Domain.Promotions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.UpdateActiveDate
{
    public sealed record UpdateActiveDateCommand : ICommand<Result>
    {
        public required PromotionId Id { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
    }
}
