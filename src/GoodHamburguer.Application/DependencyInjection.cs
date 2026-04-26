using GoodHamburguer.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
        }
    }
}
