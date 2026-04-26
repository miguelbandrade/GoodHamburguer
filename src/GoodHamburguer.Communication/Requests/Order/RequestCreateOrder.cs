namespace GoodHamburguer.Communication.Requests.Order
{
    public class RequestCreateOrder
    {
        public required string CustomerName { get; set; }
        public List<int> ProductIds { get; set; } = [];
    }
}
