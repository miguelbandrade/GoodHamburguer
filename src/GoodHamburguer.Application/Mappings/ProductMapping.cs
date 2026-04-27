using GoodHamburguer.Communication.Responses.Product;
using GoodHamburguer.Domain.Entities;
using System.Globalization;

namespace GoodHamburguer.Application.Mappings
{
    public static class ProductMapping
    {
        public static ResponseProduct ToResponse(this Product entity)
        {
            return new ResponseProduct
            {
                Id = entity.Id,
                Description = entity.Name,
                Price = entity.Price.ToString("C2", new CultureInfo("pt-BR")),
                Type = entity.Type.ToString()
            };
        }

        public static List<ResponseProduct> ToResponse(this List<Product> entities)
        {
            return [.. entities.Select(e => e.ToResponse())];
        }
    }
}
