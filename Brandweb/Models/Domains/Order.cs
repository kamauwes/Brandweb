using System.ComponentModel.DataAnnotations.Schema;

namespace Brandweb.Models.Domains
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int Product_Quantity { get; set; }
        public string Product_Name { get; set; } = string.Empty;

        public Customer Customer { get; set; }
        public int CustomerId { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
