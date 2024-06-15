using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Infrastucture.EntityMaps
{
    public class CustormerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__T_Custom__3214EC077F586E96");

            builder.ToTable("T_Customer");

            builder.Property(e => e.Address).HasMaxLength(500);
            builder.Property(e => e.Birthday).HasColumnType("datetime");
            builder.Property(e => e.Name).HasMaxLength(500);
            builder.Property(e => e.Phone).HasMaxLength(10);

        }
    }
}
