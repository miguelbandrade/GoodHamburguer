using GoodHamburguer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburguer.Infrastructure.Data.Mappings;

public class OrderProductMapping : IEntityTypeConfiguration<OrderProduct>
{
    public void Configure(EntityTypeBuilder<OrderProduct> builder)
    {
        builder.ToTable("OrderProducts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.ProductId)
            .IsRequired();

        builder.Property(x => x.OrderId)
            .IsRequired();

        builder.HasOne(e => e.Order)
            .WithMany(e => e.OrderProducts)
            .HasForeignKey(e => e.OrderId);

        builder.HasOne(e => e.Product)
            .WithMany(e => e.OrderProducts)
            .HasForeignKey(e => e.ProductId);
    }
}
