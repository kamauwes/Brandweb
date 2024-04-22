namespace Brandweb.Controllers
{
    public class AddToCartDto
    {
        public int ProductId { get; internal set; }
        public string? Product_Name { get; set; }
        public double ProductPrice { get; set; }
        public int Product_Quantity { get; set; }
        public string? Product_Image { get; set; }

    }
}