namespace Brandweb.Models.Domains
{
    public class Inventory
    {
        public int  InventoryId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public string Size { get; set; } = string.Empty;

        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
