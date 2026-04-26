using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using GoodHamburguer.Infrastructure.Data;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace GoodHamburguer.Infrastructure;

public static class DependencyInjection
{
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

        // register repositories and uow here when implemented
    }
}
