namespace Brandweb.Models.dto
{
    internal class OrderDto
    {
      
        public int Product_Quantity { get; set; }
        public string Product_Name { get; set; } = string.Empty;
        public int CustomerId { get; set; }
        public int Order_Id { get; internal set; }
    }
}