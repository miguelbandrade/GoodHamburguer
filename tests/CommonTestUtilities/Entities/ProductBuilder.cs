using Bogus;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.SharedKernel.Enum.Product;

namespace CommonTestUtilities.Entities;

public class ProductBuilder
{
    public static Product Build()
    {
        return new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Int(1, 100))
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Price, f => f.Random.Float(1, 50))
            .RuleFor(p => p.Type, f => f.PickRandom<ProductType>());
    }

    public static List<Product> Collection(int count = 2)
    {
        var list = new List<Product>();
        for (int i = 0; i < count; i++)
        {
            list.Add(Build());
        }
        return list;
    }
}
