using Application.Abstraction;
using Domain.Cars;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Commands.SetDelete
{
    public sealed record DeleteCarCommand : ICommand<Result>
    {
        public required CarId Id { get; init; }
        public required bool IsDeleted { get; init; }
    }
}
