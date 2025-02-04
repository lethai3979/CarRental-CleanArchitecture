using Application.Abstraction;
using Domain.Promotions;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Promotions.Commands.Delete
{
    public sealed record SetActivatePromotionCommand : ICommand<Result>
    {
        public required PromotionId Id { get; init; }
        public bool IsDelete { get; init; }
    }
}
