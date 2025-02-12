﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstraction;

namespace Domain.Cars
{
    public interface ICarRepository : IGenericRepository<Car, CarId>
    {
    }
}
