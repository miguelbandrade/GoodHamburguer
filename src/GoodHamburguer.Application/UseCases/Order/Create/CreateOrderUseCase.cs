using GoodHamburguer.Application.Mappings;
using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories;
using GoodHamburguer.Domain.Repositories.Orders;
using GoodHamburguer.Domain.Repositories.Products;
using GoodHamburguer.SharedKernel.Enum.Product;
using GoodHamburguer.SharedKernel.Exceptions;

namespace GoodHamburguer.Application.UseCases.Order.Create
{
    public class CreateOrderUseCase(
        IProductReadOnlyRepository productReadOnlyRepository,
        IOrderWriteOnlyRepository orderWriteOnlyRepository,
        IUnitOfWork unitOfWork) : ICreateOrderUseCase
    {
        public async Task<ResponseCreated> Execute(RequestOrder request)
        {
            var products = await productReadOnlyRepository.GetListByListId(request.ProductIds);

            if (!products.Any())
                throw new NotFoundException("Nenhum produto válido foi encontrado");

            var hasDuplicateTypes = products
                .GroupBy(p => p.Type)
                .Any(g => g.Count() > 1);
             
            if (hasDuplicateTypes)
                throw new BadRequestException("Só é possível comprar um produto de cada tipo por pedido.");

            var entity = request.ToEntity(PriceHelper.GetTotalPrice(products));

            entity.OrderProducts.AddRange(request.ProductIds.Select(e => new OrderProduct 
            {
                ProductId = e
            }));

            await orderWriteOnlyRepository.Add(entity);
            await unitOfWork.Commit();

            return new ResponseCreated { Id = entity.Id };
        }
    }
}
