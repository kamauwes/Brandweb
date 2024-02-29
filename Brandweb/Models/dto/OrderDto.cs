namespace Brandweb.Models.dto
{
    internal class OrderDto
    {
        public int Order_Id { get; set; }
        public int Product_Quantity { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int CustomerId { get; set; }
    }
}