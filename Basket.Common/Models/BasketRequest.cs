namespace Basket.Common.Models
{
    public class BasketRequest
    {
        public string UserEmail { get; set; }
        public List<Product> Products { get; set; }
    }
}
