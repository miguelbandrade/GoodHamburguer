using GoodHamburguer.Communication.Requests.Order;

namespace GoodHamburguer.Application.UseCases.Order.Update
{
    public interface IUpdateOrderUseCase
    {
        Task Execute(int id, RequestOrder request);
    }
}
