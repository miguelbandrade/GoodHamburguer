using Bogus;
using GoodHamburguer.Domain.Entities;

namespace CommonTestUtilities.Entities;

public class OrderBuilder
{
    public static Order Build()
    {
        return new Faker<Order>()
            .RuleFor(o => o.Id, f => f.Random.Int(1, 100))
            .RuleFor(o => o.CostumerName, f => f.Person.FullName)
            .RuleFor(o => o.TotalPrice, f => f.Random.Float(10, 200))
            .RuleFor(o => o.OrderProducts, _ => new List<OrderProduct>());
    }
}
