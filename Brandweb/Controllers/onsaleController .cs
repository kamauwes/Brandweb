using brand.Data;
using Brandweb.Models.Domains;
using Brandweb.Models.dto;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    public class onSaleController : ControllerBase
    {
       private readonly brandDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public onSaleController(brandDbContext usersDbContext, IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }
        // POST: api/Inventory/Insert
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddOnSaleDto addOnSaleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the product exists
            var product = await usersDbContext.Products.FindAsync(addOnSaleDto.ProductId);
            if (product == null)
            {
                return BadRequest("Product already on sale");
            }

            var onSaleDomainModel = new onSale
            {
                Product = product,
                ProductName=product.Product_Name,
               
            };
            // Update product quantity and price
         
           // product.InventoryId= addInventoryDto.ProductId;
            

            usersDbContext.OnSale.Add(onSaleDomainModel);
            await usersDbContext.SaveChangesAsync();

            return Ok("sale created");
        }


        // GET: api/Inventory/{InventoryId}
        [HttpGet("{saleId:int}")]
        public IActionResult GetById(int saleId)
        {
            var onsaleItem = usersDbContext.OnSale
                .Include(i => i.Product) // Include the associated product
                .FirstOrDefault(i => i.saleId == saleId);

            if (onsaleItem == null)
            {
                return NotFound();
            }

            // Optionally, you can create a DTO to return specific fields if needed
            var onsaleDto = new OnSaleDto
            {
                saleId = onsaleItem.saleId,
                ProductName = onsaleItem.Product.Product_Name, // Access product properties
               
                ProductPrice = onsaleItem.Product.ProductPrice, // Access product properties
                image=onsaleItem.Product.Product_Image,
                ProductId = onsaleItem.ProductId
            };

            return Ok(onsaleDto);
        }

        // GET: api/Inventory
        [HttpGet]
        public IActionResult GetAll()
        {
            var onsaleItems = usersDbContext.OnSale
                .Include(i => i.Product) // Include the associated product
                .ToList();

            // Optionally, you can create DTOs to shape the data being returned to the client
            var onsaleDtoList = onsaleItems.Select(item => new OnSaleDto
            {
                saleId = item.saleId,
                ProductName = item.Product.Product_Name, // Access product properties
                Quantity = item.Product.Product_Quantity,
                ProductPrice = item.Product.ProductPrice, // Access product properties
                image=item.Product.Product_Image,
                ProductId = item.ProductId
            }).ToList();

            return Ok(onsaleDtoList);
        }

        /*
        //POST:
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddInventoryDto addDInventoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await usersDbContext.Inventories.FirstOrDefaultAsync(c => c.ProductName == addDInventoryDto.ProductName);
            if (client != null)
            {
                return BadRequest("Already exists");
            }
            // CreatepasswordHash(addUsersDto.Password, out byte[] passwordHash
            //    , out byte[] passwordsalt);




            var InventoryDomainModel = new Inventory
            {
                
                ProductName = addDInventoryDto.ProductName,
                Quantity = addDInventoryDto.Quantity,
                ProductPrice = addDInventoryDto.ProductPrice,
                Size = addDInventoryDto.Size,
                ProductId=addDInventoryDto.ProductId,

            };

            usersDbContext.Inventories.Add(InventoryDomainModel);
            await usersDbContext.SaveChangesAsync();
            
            var UpdateInventoryDto = new AddInventoryDto
            {
               ProductName=InventoryDomainModel.ProductName,
                Quantity = InventoryDomainModel.Quantity,
                ProductPrice = InventoryDomainModel.ProductPrice,
                Size = InventoryDomainModel.Size,
                ProductId = InventoryDomainModel.ProductId,


            };

            return Ok("Inventory created");
        }
        // GET
        [HttpGet("{InventoryId:int}")]

        public IActionResult GetById(int InventoryId)
        {
            var product = usersDbContext.Inventories.Find(InventoryId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var products = usersDbContext.Inventories.ToList();
            return Ok(products);
        }
        // PUT: api/Orderdelails/{Product_Id
        [HttpPut("{InventoryId:int}")]
        public IActionResult Update(int InventoryId, [FromBody] AddInventoryDto updateDetailsDto)
        {
            var item = usersDbContext.Inventories.Find(InventoryId);
            if (item == null)
            {
                return NotFound();
            }

            // Update properties of the existing  entity
            item.Quantity = updateDetailsDto.Quantity;
            item.ProductPrice = updateDetailsDto.ProductPrice;
            item.Size = updateDetailsDto.Size;
          //  item.ProductId = updateDetailsDto.Size;
       


            // Save the changes to the database
            usersDbContext.SaveChanges();
            
            // Return the updated client DTO
            var updateddetailsDto = new Inventory
            {
              
                Quantity = item.Quantity,
                ProductPrice = item.ProductPrice,
                Size = item.Size,
                ProductId = item.ProductId,


            };
            
            // Return 200 OK response with the updated client DTO
            return Ok("updated");
        }
        */
        // DELETE: api/Products/{UserId}
        [HttpDelete("{onsaleId:int}")]
        public IActionResult DeleteById(int onsaleId)
        {
            var item = usersDbContext.OnSale.Find(onsaleId);
            if (item == null)
            {
                return NotFound();
            }

            usersDbContext.OnSale.Remove(item);
            usersDbContext.SaveChanges();

            return NoContent();
        }

    }
}
