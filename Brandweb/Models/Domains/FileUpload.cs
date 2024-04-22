using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brandweb.Models.Domains
{
    public class FileUpload
    {
        [NotMapped]
        public IFormFile file { get; set; }        
        public int ImgId { get; set; }
        public string ImageName { get; set; }

       public Product Product { get; set; }
        public  int ProductId { get; set; }
    }
}
