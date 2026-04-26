using GoodHamburguer.Communication.Requests.Order;
using GoodHamburguer.Communication.Responses.Order;
using GoodHamburguer.Domain.Entities;
using System.Globalization;

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

        public static ResponseOrder ToResponse(this Order entity)
        {
            var products = entity.OrderProducts.Select(e => e.Product).ToList();
            var priceWithoutDiscount = products.Sum(e => e!.Price);
            var discount = (priceWithoutDiscount - entity.TotalPrice) * 100 / priceWithoutDiscount;
            var discountString = $"{discount:F2}%";
            return new ResponseOrder
            {
                Id = entity.Id,
                CostumerName = entity.CostumerName,
                PriceWithoutDiscount = priceWithoutDiscount.ToString("C2", new CultureInfo("pt-BR")),
                Discount = priceWithoutDiscount != entity.TotalPrice ? discountString : string.Empty,
                TotalPrice = entity.TotalPrice.ToString("C2", new CultureInfo("pt-BR")),
                Products = products!.ToResponse()
            };
        }
    }
}
