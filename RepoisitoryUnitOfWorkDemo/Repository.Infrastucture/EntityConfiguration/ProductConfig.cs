using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Domain.Models;

namespace Repository.Infrastucture.EntityConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(e => e.Id).HasName("PK__T_Produc__3214EC07D39190D2");

            builder.ToTable("T_Product");

            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Name).HasMaxLength(100);
            builder.Property(e => e.Price).HasColumnType("numeric(18, 4)");

        }
    }
}
