using GoodHamburguer.Application.Mappings;
using GoodHamburguer.Communication.Responses.Product;
using GoodHamburguer.Domain.Repositories.Products;

namespace GoodHamburguer.Application.UseCases.Product.GetAll
{
    public class GetAllProductUseCase(IProductReadOnlyRepository productReadOnlyRepository) : IGetAllProductUseCase
    {
        public async Task<List<ResponseProduct>> Execute()
        {
            var products = await productReadOnlyRepository.GetAll();

            return products.ToResponse();
        }
    }
}
