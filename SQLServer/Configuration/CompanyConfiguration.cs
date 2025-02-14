using Domain.CarTypes;
using Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasConversion(
                companyId => companyId.value,
                value => new CompanyId(value));

            builder.HasData(
                new Company(new CompanyId(Guid.NewGuid()), "Toyota"),
                new Company(new CompanyId(Guid.NewGuid()), "Honda"),
                new Company(new CompanyId(Guid.NewGuid()), "Suzuki"),
                new Company(new CompanyId(Guid.NewGuid()), "KIA"),
                new Company(new CompanyId(Guid.NewGuid()), "Mazda")
            );
        }
    }
}
