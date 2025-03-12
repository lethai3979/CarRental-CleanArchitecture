using Domain.Bookings;
using Domain.Cars;
using Domain.CarTypes;
using Domain.Invoices;
using Domain.Promotions;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                   .HasConversion(
                       bookingId => bookingId.Value,
                       value => new BookingId(value));

            builder.Property(b => b.Status)
                   .HasConversion<string>()
                   .IsRequired();

            builder.HasOne<Car>()
                   .WithMany()
                   .HasForeignKey(b => b.CarId)
                   .IsRequired();

            builder.HasOne(b => b.Invoice)
                    .WithOne(i => i.Booking)
                    .HasForeignKey<Booking>(b => b.InvoiceId);

            builder.HasOne<Promotion>()
                   .WithMany()
                   .HasForeignKey(b => b.PromotionId);

            builder.HasOne<User>()
                   .WithMany()  
                   .HasForeignKey(b => b.UserId)
                   .HasPrincipalKey(b => b.Id);
        }
    }
}
