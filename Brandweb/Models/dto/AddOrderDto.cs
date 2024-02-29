namespace Brandweb.Models.dto
{
    public class AddOrderDto
    {
        public int Order_Id { get; set; }
        public int Product_Quantity { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int CustomerId { get; set; }
    }
}