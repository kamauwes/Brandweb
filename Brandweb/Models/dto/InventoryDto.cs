namespace Brandweb.Models.dto
{
    internal class InventoryDto
    {
        public int InventoryId { get; set; }
        public object ProductName { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
    }
}