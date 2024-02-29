namespace Brandweb.Models.dto
{
    internal class DetailsDto
    {
        public int DetailsId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public int OrderId { get; set; }

    
        public int ProductId { get; set; }
    }
}