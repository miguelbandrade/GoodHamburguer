using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories.Orders;
using Microsoft.EntityFrameworkCore;

namespace GoodHamburguer.Infrastructure.Data.Repositories
{
    public class OrderRepository(AppDbContext db) : IOrderReadOnlyRepository, IOrderWriteOnlyRepository
    {
        public async Task Add(Order order)
        {
            await db.AddAsync(order);
        }

        public async Task<List<Order>> GetAll()
        {
            return await db.Orders
                .Include(x => x.OrderProducts)
                .AsNoTracking()
                .ToListAsync();
        }

        async Task<Order?> IOrderWriteOnlyRepository.GetById(int id)
        {
            return await db.Orders
                .Include(x => x.OrderProducts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        async Task<Order?> IOrderReadOnlyRepository.GetById(int id)
        {
            return await db.Orders
                .AsNoTracking()
                .Include(x => x.OrderProducts)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
