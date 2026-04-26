namespace GoodHamburguer.Domain.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public required int ProductId { get; set; }
        public int? OrderId { get; set; }
        public Product? Product { get; set; }
        public Order? Order { get; set; }
    }
}
