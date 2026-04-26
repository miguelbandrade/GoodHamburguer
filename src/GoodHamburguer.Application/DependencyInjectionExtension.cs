using GoodHamburguer.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
        }
    }
}
