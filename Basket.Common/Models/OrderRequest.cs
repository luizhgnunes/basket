namespace Basket.Common.Models
{
    public class OrderRequest
    {
        public string UserEmail { get; set; }
        public double TotalAmount => OrderLines?.Sum(o => o.TotalPrice) ?? 0;
        public List<OrderLine> OrderLines { get; set; }

        public OrderRequest()
        {
            OrderLines = new List<OrderLine>();
        }
    }
}
