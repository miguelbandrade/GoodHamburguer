using GoodHamburguer.Domain.Repositories;

namespace GoodHamburguer.Infrastructure.Data.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        public async Task Commit()
        {
            await context.SaveChangesAsync();
        }
    }
}
