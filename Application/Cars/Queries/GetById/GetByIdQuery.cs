using Application.Abstraction.Queries;
using Domain.Cars;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Cars.Queries.GetById
{
    public sealed record GetCarByIdQuery(CarId Id) : IQuery<Result<Car>>;
}
