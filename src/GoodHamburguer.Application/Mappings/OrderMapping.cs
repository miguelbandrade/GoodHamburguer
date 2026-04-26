using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Domain.Entities;

namespace GoodHamburguer.Application.Mappings
{
    public static class OrderMapping
    {
        public static Order ToEntity(this RequestCreateOrder request, double totalPrice)
        {
            return new Order
            {
                CostumerName = request.CustomerName,
                TotalPrice = totalPrice,
            };
        }
    }
}
