namespace GoodHamburguer.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
