using Application.Abstraction;
using Domain.Companies;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Companies.Commands.Update
{
    public sealed record UpdateCompanyCommand : ICommand<Result>
    {
        public required CompanyId Id { get; set; }
        public required string Name { get; set; }
    }
}
