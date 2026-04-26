using GoodHamburguer.Communication.Responses.Product;

namespace GoodHamburguer.Communication.Responses.Order
{
    public class ResponseOrder
    {
        public required int Id { get; set; }
        public required string CostumerName { get; set; }
        public required string PriceWithoutDiscount { get; set; }
        public string? Discount { get; set; }
        public required string TotalPrice { get; set; }
        public List<ResponseProduct> Products { get; set; } = [];
    }
}
