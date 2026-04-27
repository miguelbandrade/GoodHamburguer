using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories.Products;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Data.Repositories
{
    public class ProductRepository(AppDbContext db) : IProductReadOnlyRepository
    {
        public async Task<List<Product>> GetListByListId(List<int> ids)
        {
            return await db.Products
                .AsNoTracking()
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();
        }

        public async Task<List<Product>> GetAll()
        {
            return await db.Products
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
