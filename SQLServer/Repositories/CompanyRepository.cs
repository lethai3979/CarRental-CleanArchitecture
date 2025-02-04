using Domain.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Repositories
{
    public class CompanyRepository : GenericRepository<Company, CompanyId>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
