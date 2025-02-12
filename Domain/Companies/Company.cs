using Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Companies
{
    public class Company : BaseEntity<CompanyId>
    {
        public Company(CompanyId id, string name) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; } = string.Empty;
    }
}
