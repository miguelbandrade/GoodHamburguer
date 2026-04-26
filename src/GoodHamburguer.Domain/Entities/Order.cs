namespace GoodHamburguer.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public required string CostumerName { get; set; }
        public required DateTime Date { get; set; } = DateTime.Now;
        public required float TotalPrice { get; set; }
    }
}
