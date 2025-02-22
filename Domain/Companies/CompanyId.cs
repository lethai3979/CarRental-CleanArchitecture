using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Companies
{
    public record CompanyId(Guid Value) : EntityId(Value);
}
