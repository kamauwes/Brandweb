namespace Brandweb.Models.dto
{
    public class AddInventoryDto
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public string Size { get; set; } = string.Empty;
        public int ProductId { get; set; }

    }
}