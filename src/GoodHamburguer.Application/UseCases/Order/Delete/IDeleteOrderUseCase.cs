namespace GoodHamburguer.Application.UseCases.Order.Delete
{
    public interface IDeleteOrderUseCase
    {
        Task Execute(int id);
    }
}
