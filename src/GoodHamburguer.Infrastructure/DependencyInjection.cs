using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GoodHamburguer.Infrastructure.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using GoodHamburguer.Domain.Repositories.Products;
using GoodHamburguer.Infrastructure.Data.Repositories;
using GoodHamburguer.Domain.Repositories.Orders;

using GoodHamburguer.Domain.Repositories;

namespace GoodHamburguer.Infrastructure;

public static class DependencyInjection
{
    public static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IOrderReadOnlyRepository, OrderRepository>();
        services.AddScoped<IOrderWriteOnlyRepository, OrderRepository>();

        services.AddScoped<IProductReadOnlyRepository, ProductRepository>();
    }

    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Default");
        if (string.IsNullOrWhiteSpace(connection))
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("GoodHamburguerDB"));
        }
        else
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseMySql(connection, ServerVersion.AutoDetect(connection)));
        }

        AddRepositories(services);
    }
}
