namespace Brandweb.Models.Domains
{
    public class onSale
    {
        public int saleId { get; set; }
        public string ProductName { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

    }
}