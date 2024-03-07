using Brandweb.Models.Domains;

namespace Brandweb.Models.dto
{
    public class AddDetailsDto
    {
       
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }
        public int DetailsId { get; internal set; }
    }
}