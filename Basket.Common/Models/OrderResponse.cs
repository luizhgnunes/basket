namespace Basket.Common.Models
{
    public class OrderResponse
    {
        public Guid OrderId { get; set; }
        public string UserEmail { get; set; }
        public double TotalAmount { get; set; }
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
