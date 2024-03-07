using Brandweb.Models.Domains;
using Brandweb.Models.dto;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
       private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public InventoryController(UsersDbContext usersDbContext, IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }
        // POST: api/Inventory/Insert
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddInventoryDto addInventoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Check if the product exists
            var product = await usersDbContext.Products.FindAsync(addInventoryDto.ProductId);
            if (product == null)
            {
                return BadRequest("Product does not exist");
            }

            var inventoryDomainModel = new Inventory
            {
                Product = product,
                ProductName=addInventoryDto.ProductName,
                Quantity = addInventoryDto.Quantity,
                ProductPrice = addInventoryDto.ProductPrice,
                Size = addInventoryDto.Size
            };
            // Update product quantity and price
            product.Product_Quantity = addInventoryDto.Quantity;
            product.ProductPrice = addInventoryDto.ProductPrice;
            product.InventoryId= addInventoryDto.ProductId;
            

            usersDbContext.Inventories.Add(inventoryDomainModel);
            await usersDbContext.SaveChangesAsync();

            return Ok("Inventory created");
        }


        // GET: api/Inventory/{InventoryId}
        [HttpGet("{InventoryId:int}")]
        public IActionResult GetById(int InventoryId)
        {
            var inventoryItem = usersDbContext.Inventories
                .Include(i => i.Product) // Include the associated product
                .FirstOrDefault(i => i.InventoryId == InventoryId);

            if (inventoryItem == null)
            {
                return NotFound();
            }

            // Optionally, you can create a DTO to return specific fields if needed
            var inventoryDto = new InventoryDto
            {
                InventoryId = inventoryItem.InventoryId,
                ProductName = inventoryItem.Product.Product_Name, // Access product properties
                Quantity = inventoryItem.Quantity,
                ProductPrice = inventoryItem.Product.ProductPrice, // Access product properties
                Size = inventoryItem.Size,
                ProductId = inventoryItem.ProductId
            };

            return Ok(inventoryDto);
        }

        // GET: api/Inventory
        [HttpGet]
        public IActionResult GetAll()
        {
            var inventoryItems = usersDbContext.Inventories
                .Include(i => i.Product) // Include the associated product
                .ToList();

            // Optionally, you can create DTOs to shape the data being returned to the client
            var inventoryDtoList = inventoryItems.Select(item => new InventoryDto
            {
                InventoryId = item.InventoryId,
                ProductName = item.Product.Product_Name, // Access product properties
                Quantity = item.Product.Product_Quantity,
                ProductPrice = item.Product.ProductPrice, // Access product properties
                Size = item.Size,
                ProductId = item.ProductId
            }).ToList();

            return Ok(inventoryDtoList);
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
        [HttpDelete("{DetailsId:int}")]
        public IActionResult DeleteById(int DetailsId)
        {
            var item = usersDbContext.Inventories.Find(DetailsId);
            if (item == null)
            {
                return NotFound();
            }

            usersDbContext.Inventories.Remove(item);
            usersDbContext.SaveChanges();

            return NoContent();
        }

    }
}
