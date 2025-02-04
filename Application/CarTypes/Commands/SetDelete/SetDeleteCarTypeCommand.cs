using Application.Abstraction;
using Domain.CarTypes;
using Domain.Shared;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Commands.Delete
{
    public sealed record SetDeleteCarTypeCommand : ICommand<Result>
    {
        public required CarTypeId CarTypeId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
