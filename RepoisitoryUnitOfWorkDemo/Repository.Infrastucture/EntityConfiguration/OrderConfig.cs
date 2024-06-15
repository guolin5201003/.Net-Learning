using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Domain.Models;

namespace Repository.Infrastucture.EntityConfiguration
{
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__T_Order__3214EC07B89F1FA4");

            builder.ToTable("T_Order");

            builder.Property(e => e.CreateDate).HasColumnType("datetime");
            builder.Property(e => e.CustomerId).HasColumnName("CustomerID");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.TotalPrice).HasColumnType("numeric(18, 4)");

        }
    }
}
