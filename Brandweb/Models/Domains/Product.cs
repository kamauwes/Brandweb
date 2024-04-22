using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brandweb.Models.Domains
{
    public class Product
    {
        [Required]
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public double ProductPrice { get; set; }
        public int Product_Quantity { get; set; }
     //   [NotMapped]
   //     public IFormFile file { get; set; }
        public string? Product_Image { get; set; }
        public string? Product_Description { get; set; }
        public string? Product_Category { get; set; }

        //public Stock Stock { get; set; }

        public onSale onSale { get; set; }
        public Inventory Inventory { get; set; }
       
        public int InventoryId { get; set; }
        public FileUpload fileUpload { get; set; }
        public int ImgId { get; set; }

      /*  public ICollection<OrderDetails> OrderDetails { get; set; }*/

    }
}
