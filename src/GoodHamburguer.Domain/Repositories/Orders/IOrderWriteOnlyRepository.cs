using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Repositories.Orders
{
    public interface IOrderWriteOnlyRepository
    {
        Task Add(Order order);
        Task<Order?> GetById(int id);
        void Delete(Order order);
    }
}
