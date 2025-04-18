﻿using Application.Abstraction.Queries;
using Domain.CarTypes;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CarTypes.Queries
{
    public sealed record GetByIdCarTypeQuery(CarTypeId Id) : IQuery<Result<CarType>>;
}
