using Brandweb.Models.Domains;
using Brandweb.Models.dto;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public ProductsController(UsersDbContext usersDbContext,IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }
       
        //POST:
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
        [HttpGet("products")]
        public IActionResult GetAll()
        {

            var products = usersDbContext.Products.ToList();
            return Ok(products);
        }
        // PUT: api/Products/{Product_Id
        [HttpPut("{Product_Id:int}")]
        public IActionResult Update(int Product_Id, [FromBody] AddProductsDto updateProductsDto)
        {
            var item = usersDbContext.Products.Find(Product_Id);
            if (item == null)
            {
                return NotFound();
            }

            // Update properties of the existing  entity
            item.Product_Name = updateProductsDto.Product_Name;
            item.ProductPrice = updateProductsDto.ProductPrice;
            item.Product_Description = updateProductsDto.Product_Description;
            item.Product_Category = updateProductsDto.Product_Category;
            item.Product_Quantity = updateProductsDto.Product_Quantity;
            item.Product_Image = updateProductsDto.Product_Image;

          
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
        }

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
   

    }
}
