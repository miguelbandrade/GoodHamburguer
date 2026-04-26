using GoodHamburguer.Application.UseCases.Order.Create;
using GoodHamburguer.Application.UseCases.Order.Delete;
using GoodHamburguer.Application.UseCases.Order.Get;
using GoodHamburguer.Application.UseCases.Order.GetAll;
using GoodHamburguer.Application.UseCases.Order.Update;
using Microsoft.Extensions.DependencyInjection;

namespace GoodHamburguer.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
            services.AddScoped<IDeleteOrderUseCase, DeleteOrderUseCase>();
            services.AddScoped<IGetAllOrderUseCase, GetAllOrderUseCase>();
            services.AddScoped<IGetOrderUseCase, GetOrderUseCase>();
            services.AddScoped<IUpdateOrderUseCase, UpdateOrderUseCase>();
        }
    }
}
