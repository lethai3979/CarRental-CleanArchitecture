using Domain.Bookings;
using Domain.Invoices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLServer.Configuration
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.Id)
                    .HasConversion(
                       invoiceId => invoiceId.Value,
                       value => new InvoiceId(value));

            builder.Property(i => i.BookingId).HasConversion(
                       bookingId => bookingId.Value,
                       value => new BookingId(value)).IsRequired();
        }
    }
}
