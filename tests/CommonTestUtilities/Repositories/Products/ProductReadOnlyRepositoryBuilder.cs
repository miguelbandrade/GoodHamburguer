using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories.Products;
using Moq;

namespace CommonTestUtilities.Repositories.Products;

public class ProductReadOnlyRepositoryBuilder
{
    private readonly Mock<IProductReadOnlyRepository> _repository = new();

    public ProductReadOnlyRepositoryBuilder GetListByListId(List<Product> products)
    {
        _repository.Setup(x => x.GetListByListId(It.IsAny<List<int>>())).ReturnsAsync(products);
        return this;
    }

    public IProductReadOnlyRepository Build() => _repository.Object;
}
