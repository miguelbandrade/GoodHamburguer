using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Repositories.Orders
{
    public interface IOrderReadOnlyRepository
    {
        Task<Order?> GetById(int id);
        Task<List<Order>> GetAll();
    }
}
