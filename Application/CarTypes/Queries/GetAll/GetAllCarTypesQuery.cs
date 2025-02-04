using Application.Abstraction.Queries;
using Domain.CarTypes;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Queries.GetAll
{
    public sealed record GetAllCarTypesQuery : IQuery<Result>;
}
