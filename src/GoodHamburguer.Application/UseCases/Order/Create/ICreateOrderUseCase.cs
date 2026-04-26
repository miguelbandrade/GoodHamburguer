using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;

namespace GoodHamburguer.Application.UseCases.Order.Create
{
    public interface ICreateOrderUseCase
    {
        Task<ResponseCreated> Execute(RequestCreateOrder request);
    }
}
