namespace Brandweb.Controllers
{
    public class AddProductUploadDto
    {
        
        public IFormFile file { get; set; }
        public string ImageName { get; set; }
      //  public int ProductId { get; set; }
        public double ProductPrice { get; set; }
        public int Product_Quantity { get; set; }
      

        public string? Product_Description { get; set; }
        public string? Product_Category { get; set; }
        public int InventoryId { get; set; }
    }
}