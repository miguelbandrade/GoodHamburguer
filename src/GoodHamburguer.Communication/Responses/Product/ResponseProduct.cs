namespace GoodHamburguer.Communication.Responses.Product
{
    public class ResponseProduct
    {
        public required int Id { get; set; }
        public required string Description { get; set; }
        public required string Price { get; set; }
        public required string Type { get; set; }
    }
}
