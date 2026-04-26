using Bogus;
using GoodHamburguer.Communication.Requests.Order;

namespace CommonTestUtilities.Requests;

public class RequestOrderBuilder
{
    public static RequestOrder Build(int count = 2)
    {
        return new Faker<RequestOrder>()
            .RuleFor(r => r.CustomerName, f => f.Person.FullName)
            .RuleFor(r => r.ProductIds, f => f.Make(count, () => f.Random.Int(1, 100)));
    }
}
