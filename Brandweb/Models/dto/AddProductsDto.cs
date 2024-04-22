namespace Brandweb.Models.dto
{
    public class AddProductsDto
    {
        public string? Product_Name { get; set; }
        public double ProductPrice { get; set; }
        public int Product_Quantity { get; set; }
        public string? Product_Image { get; set; }

        public string? Product_Description { get; set; }
        public string? Product_Category { get; set; }
        public int InventoryId { get; set; }
    }
}