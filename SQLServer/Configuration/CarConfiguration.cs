using Domain.Cars;
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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                    .HasConversion(
                carId => carId.Value,
                value => new CarId(value));

            builder.HasOne<CarType>()
                .WithMany()
                .HasForeignKey(c => c.CarTypeId)
                .IsRequired();

            builder.HasOne<Company>()
                .WithMany()
                .HasForeignKey(c => c.CompanyId)
                .IsRequired();

            builder.Property(c => c.Price)
                    .IsRequired();
        }
    }
}
