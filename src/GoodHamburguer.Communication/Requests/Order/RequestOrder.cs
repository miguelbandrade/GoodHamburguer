namespace GoodHamburguer.Communication.Requests.Order
{
    public class RequestOrder
    {
        public required string CustomerName { get; set; }
        public List<int> ProductIds { get; set; } = [];
    }
}
