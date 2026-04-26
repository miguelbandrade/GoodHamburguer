using GoodHamburguer.Domain.Entities;
using GoodHamburguer.SharedKernel.Enum.Product;

namespace GoodHamburguer.Application.UseCases.Order
{
    public static class PriceHelper
    {
        public static double GetTotalPrice(List<Product> products)
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
