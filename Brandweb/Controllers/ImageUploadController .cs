using Brandweb.Models.Domains;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;


namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageUploadController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        public ImageUploadController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;

        }
        [HttpPost]
        public async Task<string> Post([FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.file.Length > 0)
                {
                    string path= _webHostEnvironment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using(FileStream fileStream = System.IO.File.Create(path + fileUpload.file.FileName))
                    {
                        fileUpload.file.CopyTo(fileStream);
                        fileStream.Flush();
                        return "upload complete";
                    }
                }
                else
                {
                    return "failed";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> get([FromRoute]string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath=path+ fileName+ ".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "image/jpg");
            }
            return null;
        }
    }
}
