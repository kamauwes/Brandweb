using Brandweb.Models.Domains;
using Brandweb.Models.dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Data;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public OrdersController(UsersDbContext usersDbContext, IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }
        //POST:
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddOrderDto addOrdersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await usersDbContext.Orders.FirstOrDefaultAsync(c => c.Order_Id== addOrdersDto.Order_Id);
            if (client != null)
            {
                return BadRequest("Order already exists");
            }
        

            var OrderDomainModel = new Order
            {
                
                CustomerId=addOrdersDto.CustomerId,
                Product_Name = addOrdersDto.Product_Name,              
                Product_Quantity = addOrdersDto.Product_Quantity,
                
                
            };

            usersDbContext.Orders.Add(OrderDomainModel);
            await usersDbContext.SaveChangesAsync();

            var orderDto = new Order
            {
               Order_Id = addOrdersDto.Order_Id,
                Product_Name = OrderDomainModel.Product_Name,
                CustomerId=OrderDomainModel.CustomerId,             
                Product_Quantity = OrderDomainModel.Product_Quantity,
            
            };

            return Ok($"Order placed,{orderDto.Product_Name}");
        }
        /*[HttpGet]
        public IActionResult GetAll()
        {
            var products = usersDbContext.Orders.ToList();
            return Ok(products);
        }*/
        // DELETE: api/Products/{UserId}
        [HttpDelete("{Order_Id:int}")]
        public IActionResult DeleteById(int Order_Id)
        {
            var item = usersDbContext.Orders.Find(Order_Id);
            if (item == null)
            {
                return NotFound();
            }

            usersDbContext.Orders.Remove(item);
            usersDbContext.SaveChanges();

            return NoContent();
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var OrderItems = usersDbContext.Orders
                .Include(i => i.Customer) // Include the associated product
                .ToList();

            // Optionally, you can create DTOs to shape the data being returned to the client
            var OrdersDtoList = OrderItems.Select(item => new OrderDto
            {
                Order_Id=item.Order_Id,
                CustomerId = item.Customer.Id,
                Product_Name = item.Product_Name,
                Product_Quantity = item.Product_Quantity,
                
                /*
                InventoryId = item.InventoryId,
                ProductName = item.Product.Product_Name, // Access product properties
                Quantity = item.Product.Product_Quantity,
                ProductPrice = item.Product.ProductPrice, // Access product properties
                Size = item.Size,
                ProductId = item.ProductId*/
            }).ToList();

            return Ok(OrdersDtoList);
        }
    }
}
