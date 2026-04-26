using GoodHamburguer.Domain.Repositories;
using GoodHamburguer.Domain.Repositories.Orders;
using GoodHamburguer.SharedKernel.Exceptions;

namespace GoodHamburguer.Application.UseCases.Order.Delete
{
    public class DeleteOrderUseCase(
        IOrderWriteOnlyRepository orderWriteOnlyRepository,
        IUnitOfWork unitOfWork) : IDeleteOrderUseCase
    {
        public async Task Execute(int id)
        {
            var entity = await orderWriteOnlyRepository.GetById(id)
                ?? throw new NotFoundException("O pedido não foi encontrado.");

            orderWriteOnlyRepository.Delete(entity);
            await unitOfWork.Commit();
        }
    }
}
