using Domain.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class CarRepository : GenericRepository<Car, CarId>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
