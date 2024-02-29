using System.ComponentModel.DataAnnotations;

namespace Brandweb.Models.Dto
{
    internal class ProductDto
    {
        [Required]
        public int Product_Id { get; set; }
        public string? Product_Name { get; set; }
        public double ProductPrice { get; set; }
        public int Product_Quantity { get; set; }
        public string? Product_Image { get; set; }
        public string? Product_Description { get; set; }
        public string? Product_Category { get; set; }

        /*
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; } = new byte[32];
        public byte[] PasswordSalt { get; set; } = new byte[32];
        public string? VerificationToken { get; set; }
        public DateTime? VerifiedAt { get; set; }
        public string? PasswordResetToken { get; set; }
        public DateTime? ResetTokenExpires { get; set; }*/
    }
}