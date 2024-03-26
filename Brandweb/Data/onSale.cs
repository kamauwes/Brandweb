using Brandweb.Models.Domains;

namespace User.Data
{
    public class onSale
    {
        public int saleId { get; set; }
        public string ProductName { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }
        
    }
}