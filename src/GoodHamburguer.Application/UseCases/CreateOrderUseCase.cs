using GoodHamburguer.Application.Mappings;
using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses;
using GoodHamburguer.Domain.Entities;
using GoodHamburguer.Domain.Repositories;
using GoodHamburguer.Domain.Repositories.Orders;
using GoodHamburguer.Domain.Repositories.Products;
using GoodHamburguer.SharedKernel.Enum.Product;

namespace GoodHamburguer.Application.UseCases
{
    public class CreateOrderUseCase(
        IProductReadOnlyRepository productReadOnlyRepository,
        IOrderWriteOnlyRepository orderWriteOnlyRepository,
        IUnitOfWork unitOfWork) : ICreateOrderUseCase
    {
        public async Task<ResponseCreated> Execute(RequestCreateOrder request)
        {
            var products = await productReadOnlyRepository.GetListByListId(request.ProductIds);

            if (!products.Any())
                throw new Exception("Nenhum produto válido foi encontrado");

            var hasDuplicateTypes = products
                .GroupBy(p => p.Type)
                .Any(g => g.Count() > 1);

            if (hasDuplicateTypes)
                throw new Exception("Só é possível comprar um produto de cada tipo por pedido.");

            var entity = request.ToEntity(GetTotalPrice(products));

            entity.OrderProducts.AddRange(request.ProductIds.Select(e => new OrderProduct 
            {
                ProductId = e
            }));

            await orderWriteOnlyRepository.Add(entity);
            await unitOfWork.Commit();

            return new ResponseCreated { Id = entity.Id };
        }

        private double GetTotalPrice(List<Product> products)
        {
            var totalWithoutDescount = products.Sum(e => e.Price);

            if (products.Any(e => e.Type == ProductType.Hamburguer)
                && products.Any(e => e.Type == ProductType.Drink
                && products.Any(e => e.Type == ProductType.Fries)))
                return totalWithoutDescount - (totalWithoutDescount * 0.20);

            if (products.Any(e => e.Type == ProductType.Hamburguer)
                && products.Any(e => e.Type == ProductType.Fries))
                return totalWithoutDescount - (totalWithoutDescount * 0.10);

            if (products.Any(e => e.Type == ProductType.Hamburguer)
                && products.Any(e => e.Type == ProductType.Drink))
                return totalWithoutDescount - (totalWithoutDescount * 0.15);

            return totalWithoutDescount;
        }   
    }
}
