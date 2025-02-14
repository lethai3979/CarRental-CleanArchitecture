using Domain.CarTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Configuration
{
    public class CarTypeConfiguration : IEntityTypeConfiguration<CarType>
    {
        public void Configure(EntityTypeBuilder<CarType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Id).HasConversion(
                carTypeId => carTypeId.Value,
                value => new CarTypeId(value));
            builder.Property(c => c.Id);

            builder.HasData(
                new CarType(new CarTypeId(Guid.NewGuid()), "Sedan"),
                new CarType(new CarTypeId(Guid.NewGuid()), "SUV"),
                new CarType(new CarTypeId(Guid.NewGuid()), "Hatchback"),
                new CarType(new CarTypeId(Guid.NewGuid()), "Crossover"),
                new CarType(new CarTypeId(Guid.NewGuid()), "Pickup")
            );
        }
    }
}
