using GoodHamburguer.Domain.Entities;
using GoodHamburguer.SharedKernel.Enum.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GoodHamburguer.Infrastructure.Data.Mappings;

public class ProductMapping : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired();

        builder.Property(x => x.Price)
            .IsRequired();

        builder.Property(x => x.Type)
            .IsRequired();

        builder.HasData(
            new Product { Id = 1, Name = "X Burger", Price = 5.00f, Type = ProductType.Hamburguer },
            new Product { Id = 2, Name = "X Egg", Price = 4.50f, Type = ProductType.Hamburguer },
            new Product { Id = 3, Name = "X Bacon", Price = 7.00f, Type = ProductType.Hamburguer },
            new Product { Id = 4, Name = "Batata frita", Price = 2.00f, Type = ProductType.Fries },
            new Product { Id = 5, Name = "Refrigerante", Price = 2.50f, Type = ProductType.Drink }
        );
    }
}
