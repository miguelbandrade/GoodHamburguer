using GoodHamburguer.Communication.Responses.Order;

namespace GoodHamburguer.Application.UseCases.Order.Get
{
    public interface IGetOrderUseCase
    {
        Task<ResponseOrder> Execute(int id);
    }
}
