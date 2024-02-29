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
       /*private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public InventoryController(UsersDbContext usersDbContext, IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }

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
                

            };

            usersDbContext.Inventories.Add(InventoryDomainModel);
            await usersDbContext.SaveChangesAsync();
            /*
            var UpdateDetailsDto = new DetailsDto
            {
               
                Quantity = DetailsDomainModel.Quantity,
                UnitPrice = DetailsDomainModel.UnitPrice,
                OrderId = DetailsDomainModel.OrderId,
                ProductId = DetailsDomainModel.ProductId,


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
            /*
            // Return the updated client DTO
            var updateddetailsDto = new Inventory
            {
              
                Quantity = item.Quantity,
                ProductPrice = item.UnitPrice,
                OrderId = item.OrderId,
                ProductId = item.ProductId,


            };
            
            // Return 200 OK response with the updated client DTO
            return Ok("updated");
        }

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
        }*/

    }
}
