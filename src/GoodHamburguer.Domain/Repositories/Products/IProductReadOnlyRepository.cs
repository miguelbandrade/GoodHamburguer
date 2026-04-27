using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Domain.Repositories.Products
{
    public interface IProductReadOnlyRepository
    {
        Task<List<Product>> GetListByListId(List<int> ids);
        Task<List<Product>> GetAll();
    }
}