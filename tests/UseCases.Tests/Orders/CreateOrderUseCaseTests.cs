using CommonTestUtilities.Entities;
using CommonTestUtilities.Repositories;
using CommonTestUtilities.Repositories.Orders;
using CommonTestUtilities.Repositories.Products;
using CommonTestUtilities.Requests;
using FluentAssertions;
using GoodHamburguer.Application.UseCases.Order.Create;
using GoodHamburguer.SharedKernel.Exceptions;
using Moq;

namespace UseCases.Tests.Orders;

public class CreateOrderUseCaseTests
{
    [Fact]
    public async Task Execute_Success()
    {
        // Arrange
        var request = RequestOrderBuilder.Build();
        var products = ProductBuilder.Collection(request.ProductIds.Count);
        // Ensure unique types to pass validation
        for (int i = 0; i < products.Count; i++) products[i].Type = (GoodHamburguer.SharedKernel.Enum.Product.ProductType)i;

        var productRepo = new ProductReadOnlyRepositoryBuilder().GetListByListId(products).Build();
        var orderRepo = new OrderWriteOnlyRepositoryBuilder().Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new CreateOrderUseCase(productRepo, orderRepo, uow);

        // Act
        var result = await useCase.Execute(request);

        // Assert
        result.Should().NotBeNull();
        Mock.Get(orderRepo).Verify(x => x.Add(It.IsAny<GoodHamburguer.Domain.Entities.Order>()), Times.Once);
        Mock.Get(uow).Verify(x => x.Commit(), Times.Once);
    }

    [Fact]
    public async Task Execute_Error_ProductsNotFound()
    {
        // Arrange
        var request = RequestOrderBuilder.Build();
        var productRepo = new ProductReadOnlyRepositoryBuilder().GetListByListId(new List<GoodHamburguer.Domain.Entities.Product>()).Build();
        var orderRepo = new OrderWriteOnlyRepositoryBuilder().Build();
        var uow = new UnitOfWorkBuilder().Build();

        var useCase = new CreateOrderUseCase(productRepo, orderRepo, uow);

        // Act
        var act = async () => await useCase.Execute(request);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>();
    }
}
