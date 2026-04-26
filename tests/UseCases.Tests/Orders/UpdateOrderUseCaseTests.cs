using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Orders;
using CommonTestUtilities.Repositories.Products;
using CommonTestUtilities.Requests;
using FluentAssertions;
using GoodHamburguer.Application.UseCases.Order.Update;
using GoodHamburguer.SharedKernel.Exceptions;
using Moq;

namespace UseCases.Tests.Orders;

public class UpdateOrderUseCaseTests
{
    [Fact]
    public async Task Execute_Success()
    {
        // Arrange
        var order = OrderBuilder.Build();
        var request = RequestOrderBuilder.Build(1);
        var products = ProductBuilder.Collection(1);

        var orderRepo = new OrderWriteOnlyRepositoryBuilder().GetById(order).Build();
        var productRepo = new ProductReadOnlyRepositoryBuilder().GetListByListId(products).Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new UpdateOrderUseCase(orderRepo, productRepo, uow);

        // Act
        await useCase.Execute(order.Id, request);

        // Assert
        order.CostumerName.Should().Be(request.CustomerName);
        Mock.Get(uow).Verify(x => x.Commit(), Times.Once);
    }

    [Fact]
    public async Task Execute_Error_OrderNotFound()
    {
        // Arrange
        var request = RequestOrderBuilder.Build();
        var orderRepo = new OrderWriteOnlyRepositoryBuilder().GetById(null).Build();
        var productRepo = new ProductReadOnlyRepositoryBuilder().Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new UpdateOrderUseCase(orderRepo, productRepo, uow);

        // Act
        var act = async () => await useCase.Execute(1, request);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
