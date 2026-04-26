using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Orders;
using FluentAssertions;
using GoodHamburguer.Application.UseCases.Order.Delete;
using GoodHamburguer.SharedKernel.Exceptions;
using Moq;

namespace UseCases.Tests.Orders;

public class DeleteOrderUseCaseTests
{
    [Fact]
    public async Task Execute_Success()
    {
        // Arrange
        var order = OrderBuilder.Build();
        var orderRepo = new OrderWriteOnlyRepositoryBuilder().GetById(order).Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new DeleteOrderUseCase(orderRepo, uow);

        // Act
        await useCase.Execute(order.Id);

        // Assert
        Mock.Get(orderRepo).Verify(x => x.Delete(order), Times.Once);
        Mock.Get(uow).Verify(x => x.Commit(), Times.Once);
    }

    [Fact]
    public async Task Execute_Error_OrderNotFound()
    {
        // Arrange
        var orderRepo = new OrderWriteOnlyRepositoryBuilder().GetById(null).Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new DeleteOrderUseCase(orderRepo, uow);

        // Act
        var act = async () => await useCase.Execute(1);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
