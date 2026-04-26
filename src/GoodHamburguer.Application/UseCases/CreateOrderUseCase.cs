using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;

namespace GoodHamburguer.Application.UseCases
{
    public class CreateOrderUseCase : ICreateOrderUseCase
    {
        public async Task<ResponseCreated> Execute(RequestCreateOrder request)
        {
            await Task.Delay(500);

            return new ResponseCreated { Id = new Random().Next(1, 1000) };
        }
    }
}
