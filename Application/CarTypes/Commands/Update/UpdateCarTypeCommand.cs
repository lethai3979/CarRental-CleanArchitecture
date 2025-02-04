using Application.Abstraction;
using Domain.CarTypes;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Commands.Update
{
    public sealed record UpdateCarTypeCommand : ICommand<Result>
    {
        public required CarTypeId Id { get; set; }
        public required string Name { get; set; }
    }
}
