namespace Basket.Common.Models
{
    public class OrderRequest
    {
        public string UserEmail { get; set; }
        public double TotalAmount => OrderLines?.Sum(o => o.TotalPrice) ?? 0;
        public IEnumerable<OrderLine> OrderLines { get; set; }
    }
}
