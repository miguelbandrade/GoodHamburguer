using GoodHamburguer.Communication.Responses.Product;

namespace GoodHamburguer.Application.UseCases.Product.GetAll
{
    public interface IGetAllProductUseCase
    {
        Task<List<ResponseProduct>> Execute();
    }
}
