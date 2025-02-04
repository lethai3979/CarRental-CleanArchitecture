using Application.Abstraction;
using Domain.Promotions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.UpdateInfo
{
    public sealed record UpdatePromotionInfoCommand : ICommand<Result>
    {
        public required PromotionId Id { get; init; }
        public required string Content { get; init; }
        public required double DiscountValue { get; init; }
    }
}
