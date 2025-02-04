using System;
using Domain.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Cars
{
    public interface ICarRepository : IGenericRepository<Car, CarId>
    {
    }
}
