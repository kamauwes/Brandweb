
namespace Brandweb.Controllers
{
    internal class UploadDto
    {
        public string ImgId { get; set; }
        public int ProductId { get; set; }
        public string ImageName { get; set; }
        public IFormFile file { get; set; }
    }
}