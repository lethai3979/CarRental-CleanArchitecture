﻿using Application.Abstraction.Queries;
using Domain.Cars;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Queries.GetAll
{
    public sealed record GetAllCarsQuery : IQuery<Result<List<Car>>>;
}
