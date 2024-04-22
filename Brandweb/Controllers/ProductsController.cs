using brand.Data;
using Brandweb.Models.Domains;
using Brandweb.Models.dto;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ProductsController : ControllerBase
    {   
        private readonly brandDbContext usersDbContext;
        private readonly IConfiguration configuration;
        public static IWebHostEnvironment _webHostEnvironment;

        public ProductsController(brandDbContext usersDbContext,IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {   
            _webHostEnvironment = webHostEnvironment;
            this.usersDbContext = usersDbContext;
 
            this.configuration = configuration;
        }

        //POST:
      /*  [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddProductsDto addProductsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Check if the product name already exists in the database
                var existingProduct = await usersDbContext.Products.FirstOrDefaultAsync(p => p.Product_Name == addProductsDto.Product_Name);
                if (existingProduct != null)
                {
                    return BadRequest("Product already exists");
                }

                // Save the uploaded file to the specified folder
                if (addProductsDto.file != null && addProductsDto.file.Length > 0)
                {
                    string folderPath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + addProductsDto.file.FileName;
                    string filePath = Path.Combine(folderPath, uniqueFileName);
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await addProductsDto.file.CopyToAsync(fileStream);
                    }

                    // Create a new product entity
                    var product = new Product
                    {
                        Product_Name = addProductsDto.Product_Name,
                        ProductPrice = addProductsDto.ProductPrice,
                        Product_Description = addProductsDto.Product_Description,
                        Product_Quantity = addProductsDto.Product_Quantity,
                        Product_Category = addProductsDto.Product_Category,
                        Product_Image = addProductsDto.Product_Name,
                        InventoryId = addProductsDto.InventoryId
                    };

                    // Add the product entity to the database context and save changes
                    usersDbContext.Products.Add(product);
                    await usersDbContext.SaveChangesAsync();

                    // Create a new upload entity
                    var products = new Product
                    {
                        Product_Name = addProductsDto.Product_Name,
                        Product_Image = uniqueFileName, // Save the unique file name in the database
                                                        // Include other properties of the product as needed
                    };


                    // Add the upload entity to the database context and save changes
                    usersDbContext.Products.Add(products);
                    await usersDbContext.SaveChangesAsync();

                    return Ok("Product and upload data saved successfully");
                }
                else
                {
                    return BadRequest("No file uploaded");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/

         [HttpPost("Insert")]
         public async Task<IActionResult> Insert([FromBody] AddProductsDto addProductsDto)
         {
             if (!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             var client = await usersDbContext.Products.FirstOrDefaultAsync(c => c.Product_Name == addProductsDto.Product_Name);
             if (client != null)
             {
                 return BadRequest("User already exists");
             }

             var ProductDomainModel = new Product
             {
                 Product_Name = addProductsDto.Product_Name,
                 ProductPrice = addProductsDto.ProductPrice,
                 Product_Description = addProductsDto.Product_Description,
                 Product_Quantity = addProductsDto.Product_Quantity,
                 Product_Category = addProductsDto.Product_Category,
                 Product_Image = addProductsDto.Product_Image,
                 InventoryId= addProductsDto.InventoryId

             };

             usersDbContext.Products.Add(ProductDomainModel);
             await usersDbContext.SaveChangesAsync();

             var productDto = new ProductDto
             {
                 Product_Id = ProductDomainModel.Product_Id,
                 Product_Name = ProductDomainModel.Product_Name,
                 ProductPrice = ProductDomainModel.ProductPrice,
                 Product_Description = ProductDomainModel.Product_Description,
                 Product_Category = ProductDomainModel.Product_Category,
                 Product_Quantity = ProductDomainModel.Product_Quantity,
                 Product_Image = ProductDomainModel.Product_Image,

             };

             return Ok(productDto);
         }
        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddProductUploadDto productUploadDto)
        {
            try
            {
                if (productUploadDto.file.Length > 0)
                {
                    /*  string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string uploadsPath = Path.Combine(desktopPath, "uploads");
                  string   */

                    string uploadsPath = "\\projectsfile\\Brandweb\\angurlar\\brandwed\\src\\assets\\products";

                    // Ensure that the uploads directory exists
                    if (!Directory.Exists(uploadsPath))
                    {
                        Directory.CreateDirectory(uploadsPath);
                    }
                    

                    // Generate a unique filename for the uploaded file
                    string uniqueFileName = productUploadDto.file.FileName;

                    // Create the full file path including the uploads directory
                    string filePath = Path.Combine(uploadsPath, uniqueFileName);

                    // Save the uploaded file to the specified path
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productUploadDto.file.CopyToAsync(fileStream);
                    }

                    // Create a product entity with the necessary details
                    var product = new Product
                    {
                        Product_Name = productUploadDto.ImageName,
                        Product_Image = uniqueFileName, // Save the unique file name in the database
                        ProductPrice = productUploadDto.ProductPrice,
                        Product_Description = productUploadDto.Product_Description,
                        Product_Quantity = productUploadDto.Product_Quantity,
                        Product_Category = productUploadDto.Product_Category,
                        InventoryId = productUploadDto.InventoryId
                        // Include other properties of the product as needed
                    };

                    // Add the product entity to the database context and save changes
                    usersDbContext.Products.Add(product);
                    await usersDbContext.SaveChangesAsync();

                    return Ok(productUploadDto);
                }
                else
                {
                    return BadRequest("No file uploaded");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // GET
        [HttpGet("{Id:int}")]

        public IActionResult GetById(int Id)
        {
            var product = usersDbContext.Products.Find(Id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet("{fileName}")]
        public IActionResult GetById(string fileName)
        {

            
            try
            {
              /*  string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string uploadsPath = Path.Combine(desktopPath, "uploads");
              string 
*/
              string uploadsPath = "\\projectsfile\\Brandweb\\angurlar\\brandwed\\src\\assets\\products"; 
              
                // Create the full file path including the uploads directory
                string filePath = Path.Combine(uploadsPath, fileName);

                // Check if the file exists
                if (System.IO.File.Exists(filePath))
                {
                    // Read the file contents into a byte array
                    byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);

                    // Determine the content type based on the file extension
                    string contentType = GetContentType(fileName);

                    // Return the file content with the appropriate content type
                    return File(fileBytes, contentType);
                }
                else
                {
                    // If the file doesn't exist, return a 404 Not Found response
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, return a 500 Internal Server Error response
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // Helper method to determine the content type based on the file extension
        private string GetContentType(string fileName)
        {
            // Get the file extension
            string extension = Path.GetExtension(fileName);

            // Map common file extensions to MIME types
            switch (extension.ToLower())
            {
                case ".jpg":
                case ".jpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".gif":
                    return "image/gif";
                // Add more cases for other file types as needed
                default:
                    return "application/octet-stream"; // Default to binary data if the file type is unknown
            }
        }
    /*
        [HttpGet("{fileName}")]
        public async Task<IActionResult> get(string fileName)
        {
            string desktopPath = _webHostEnvironment.WebRootPath + "\\uploads\\";
            var filePath = desktopPath + fileName + ".jpg";
            if (System.IO.File.Exists(filePath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(filePath);
                return File(bytes, "image/jpg");
            }
            return null;
        }*/
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await usersDbContext.Products.ToListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] AddProductUploadDto productUploadDto)
        {
            try
            {
                var product = await usersDbContext.Products.FindAsync(id);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                if (productUploadDto.file != null && productUploadDto.file.Length > 0)
                {
                    // Generate a unique filename for the uploaded file
                    string uniqueFileName = productUploadDto.file.FileName;

                    // Create the full file path including the uploads directory
                    string filePath = Path.Combine("\\projectsfile\\Brandweb\\angurlar\\brandwed\\src\\assets\\products", uniqueFileName);

                    // Save the uploaded file to the specified path
                    using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productUploadDto.file.CopyToAsync(fileStream);
                    }

                    // Update product details with the new information
                    product.Product_Name = productUploadDto.ImageName;
                    product.Product_Image = uniqueFileName; // Save the unique file name in the database
                    product.ProductPrice = productUploadDto.ProductPrice;
                    product.Product_Description = productUploadDto.Product_Description;
                    product.Product_Quantity = productUploadDto.Product_Quantity;
                    product.Product_Category = productUploadDto.Product_Category;
                    product.InventoryId = productUploadDto.InventoryId;
                    // Include other properties of the product as needed

                    // Update the product entity in the database context
                    usersDbContext.Products.Update(product);
                    await usersDbContext.SaveChangesAsync();

                    return Ok(productUploadDto);
                }
                else
                {
                    return BadRequest("No file uploaded or file is empty");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        // PUT: api/Products/{Product_Id
   /*     [HttpPut("{Product_Id:int}")]
        public IActionResult Update(int Product_Id, [FromBody] AddProductsDto updateProductsDto)
        {
            var item = usersDbContext.Products.Find(Product_Id);
            if (item == null)
            {
                return NotFound();
            }

            // properties of the existing  entity
   
            item.ProductPrice = updateProductsDto.ProductPrice;
            item.Product_Description = updateProductsDto.Product_Description;
            item.Product_Category = updateProductsDto.Product_Category;
            item.Product_Quantity = updateProductsDto.Product_Quantity;
       

          
            // Save the changes to the database
            usersDbContext.SaveChanges();

            // Return the updated client DTO
            var updatedProductsDto = new ProductDto
            {
                Product_Id=item.Product_Id,
                Product_Name = item.Product_Name,
                ProductPrice = item.ProductPrice,
                Product_Description = item.Product_Description,
                Product_Category = item.Product_Category,
                Product_Quantity = item.Product_Quantity,
                Product_Image = item.Product_Image,

                
            };

            // Return 200 OK response with the updated client DTO
            return Ok(updatedProductsDto);
        }*/

        // DELETE: api/Products/{UserId}
        [HttpDelete("{Product_Id:int}")]
        public IActionResult DeleteById(int Product_Id)
        {
            var item = usersDbContext.Products.Find(Product_Id);
            if (item == null)
            {
                return NotFound();
            }

            usersDbContext.Products.Remove(item);
            usersDbContext.SaveChanges();

            return NoContent();
        }
        // POST: api/Products/AddToCart
  /*      [HttpPost("AddToCart")]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartDto addToCartDto)
        {
            try
            {
                var product = await usersDbContext.Products.FirstOrDefaultAsync(p => p.Product_Id == addToCartDto.ProductId);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                // Check if the quantity requested is available
                if (product.Product_Quantity < addToCartDto.Quantity)
                {
                    return BadRequest("Insufficient quantity available");
                }

                // Reduce the available quantity of the product
                product.Product_Quantity -= addToCartDto.Quantity;

                // Update the product entity in the database context
                usersDbContext.Products.Update(product);
                await usersDbContext.SaveChangesAsync();

                // Return a success message or any other relevant data
                return Ok($"Added {addToCartDto.Quantity} units of {product.Product_Name} to cart");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }*/
   

    }
}
