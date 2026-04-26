using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories.Orders;
using Moq;

namespace CommonTestUtilities.Repositories.Orders
{
    public class OrderReadOnlyRepositoryBuilder
    {
        private readonly Mock<IOrderReadOnlyRepository> _repository = new();

        public OrderReadOnlyRepositoryBuilder GetByGuid(Order? order)
        {
            if(order is not null)
                _repository.Setup(e => e.GetById(order.Id)).ReturnsAsync(order);

            return this;
        }

        public IOrderReadOnlyRepository Build() => _repository.Object;
    }
}
