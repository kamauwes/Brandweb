namespace Brandweb.Models.dto
{
    public class ProductUpdateDto
    {
        public int InventoryId { get; internal set; }
        public double ProductPrice { get; internal set; }
        public int Quantity { get; internal set; }
    }
}