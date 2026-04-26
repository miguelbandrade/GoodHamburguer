using GoodHamburguer.Domain.Repositories;
using Moq;

namespace CommonTestUtilities.Repositories;

public class UnitOfWorkBuilder
{
    private readonly Mock<IUnitOfWork> _mock = new();

    public IUnitOfWork Build() => _mock.Object;
}
