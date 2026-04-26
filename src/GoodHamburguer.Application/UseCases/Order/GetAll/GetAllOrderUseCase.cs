using GoodHamburguer.Application.Mappings;
using GoodHamburguer.Communication.Responses.Order;
using GoodHamburguer.Domain.Repositories.Orders;

namespace GoodHamburguer.Application.UseCases.Order.GetAll
{
    public class GetAllOrderUseCase(IOrderReadOnlyRepository orderReadOnlyRepository) : IGetAllOrderUseCase
    {
        public async Task<List<ResponseShortOrder>> Execute()
        {
            var orders = await orderReadOnlyRepository.GetAll();

            return orders.ToShortResponse();
        }
    }
}
