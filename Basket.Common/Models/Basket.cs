namespace Basket.Common.Models
{
    public class Basket
    {
        public Guid Id { get; set; }
        public OrderRequest OrderRequest { get; set; }

        public Basket()
        {
            Id = Guid.NewGuid();
            OrderRequest = new OrderRequest();
        }

        public Basket(Guid id, OrderRequest orderRequest)
        {
            Id = id;
            OrderRequest = orderRequest;
        }
    }
}
