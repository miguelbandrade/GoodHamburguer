using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories.Orders;
using Moq;

namespace CommonTestUtilities.Repositories.Orders;

public class OrderWriteOnlyRepositoryBuilder
{
    private readonly Mock<IOrderWriteOnlyRepository> _repository = new();

    public OrderWriteOnlyRepositoryBuilder GetById(Order? order)
    {
        if (order is not null)
            _repository.Setup(e => e.GetById(order.Id)).ReturnsAsync(order);

        return this;
    }

    public IOrderWriteOnlyRepository Build() => _repository.Object;
}
