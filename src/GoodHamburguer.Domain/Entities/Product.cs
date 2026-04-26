using GoodHamburguer.SharedKernel.Enum.Product;

namespace GoodHamburguer.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required float Price { get; set; }
        public required ProductType Type { get; set; }
    }
}
