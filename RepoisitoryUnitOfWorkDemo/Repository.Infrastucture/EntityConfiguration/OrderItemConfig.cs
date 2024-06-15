using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Domain.Models;

namespace Repository.Infrastucture.EntityConfiguration
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__T_OrderI__3214EC070C3198E4");

            builder.ToTable("T_OrderItem");

            builder.Property(e => e.CreateDate).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.OrderId).HasColumnName("OrderID");
            builder.Property(e => e.Price).HasColumnType("numeric(18, 4)");
            builder.Property(e => e.ProductId).HasColumnName("ProductID");

        }
    }
}
