namespace Brandweb.Models.Domains
{
    public class OrderDetails
    {
        public int DetailsId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}
