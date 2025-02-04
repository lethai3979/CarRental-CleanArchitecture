using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarTypes
{
    public class CarType : BaseEntity<CarTypeId>
    {
        public CarType(CarTypeId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
    }
}
