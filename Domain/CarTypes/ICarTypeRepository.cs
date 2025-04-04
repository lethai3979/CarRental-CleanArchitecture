﻿using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarTypes
{
    public interface ICarTypeRepository : IGenericRepository<CarType, CarTypeId>
    {
    }
}
