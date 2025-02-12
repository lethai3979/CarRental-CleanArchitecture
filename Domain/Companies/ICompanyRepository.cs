using Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Companies
{
    public interface ICompanyRepository : IGenericRepository<Company, CompanyId>
    {
    }
}
