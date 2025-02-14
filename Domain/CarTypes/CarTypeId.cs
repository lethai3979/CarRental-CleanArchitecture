using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.CarTypes
{
    public record CarTypeId(Guid Value) : EntityId(Value);
}
