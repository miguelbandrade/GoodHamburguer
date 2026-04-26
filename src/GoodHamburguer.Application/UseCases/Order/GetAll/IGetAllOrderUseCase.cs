using GoodHamburguer.Communication.Responses.Order;

namespace GoodHamburguer.Application.UseCases.Order.GetAll
{
    public interface IGetAllOrderUseCase
    {
        Task<List<ResponseShortOrder>> Execute();
    }
}
