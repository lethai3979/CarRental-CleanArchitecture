using Domain.CarTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public sealed class CarTypeRepository : GenericRepository<CarType, CarTypeId>, ICarTypeRepository
    {
        public CarTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
