namespace GoodHamburguer.Domain.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public required int ProductId { get; set; }
        public required int OrderId { get; set; }
    }
}
