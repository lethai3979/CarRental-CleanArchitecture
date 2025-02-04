using Application.Abstraction;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Commands.Add
{
    public sealed record CreateCarTypeCommand : ICommand<Result>
    {
        public required string Name { get; set; }
    }
}
