using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;

namespace GoodHamburguer.Application.UseCases
{
    public interface ICreateOrderUseCase
    {
        Task<ResponseCreated> Execute(RequestCreateOrder request);
    }
}
