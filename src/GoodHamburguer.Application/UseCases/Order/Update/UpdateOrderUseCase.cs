using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories;
using GoodHamburguer.Domain.Repositories.Orders;
using GoodHamburguer.Domain.Repositories.Products;
using GoodHamburguer.SharedKernel.Exceptions;

namespace GoodHamburguer.Application.UseCases.Order.Update
{
    public class UpdateOrderUseCase(
        IOrderWriteOnlyRepository orderWriteOnlyRepository,
        IProductReadOnlyRepository productReadOnlyRepository,
        IUnitOfWork unitOfWork) : IUpdateOrderUseCase
    {
        public async Task Execute(int id, RequestOrder request)
        {
            var order = await orderWriteOnlyRepository.GetById(id)
                ?? throw new NotFoundException("Pedido não encontrado."); ;

            var products = await productReadOnlyRepository.GetListByListId(request.ProductIds);

            if (!products.Any())
                throw new BadRequestException("Os produtos informados são invalidos");

            order.CostumerName = request.CustomerName;
            order.TotalPrice = PriceHelper.GetTotalPrice(products);

            order.OrderProducts.Clear();
            order.OrderProducts.AddRange(request.ProductIds.Select(e => new OrderProduct
            {
                ProductId = e,
                OrderId = order.Id
            }));

            await unitOfWork.Commit();
        }
    }
}
