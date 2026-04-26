namespace GoodHamburguer.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string CostumerName { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public required double TotalPrice { get; set; }
        public List<OrderProduct> OrderProducts { get; set; } = [];
    }
}
