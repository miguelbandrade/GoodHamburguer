using GoodHamburguer.Application.Mappings;
using GoodHamburguer.Communication.Responses.Order;
using GoodHamburguer.Domain.Repositories.Orders;
using GoodHamburguer.SharedKernel.Exceptions;

namespace GoodHamburguer.Application.UseCases.Order.Get
{
    public class GetOrderUseCase(IOrderReadOnlyRepository orderReadOnlyRepository) : IGetOrderUseCase
    {
        public async Task<ResponseOrder> Execute(int id)
        {
            var order = await orderReadOnlyRepository.GetById(id)
                ?? throw new NotFoundException("O pedido não foi encontrado.");

            return order.ToResponse();
        }
    }
}
