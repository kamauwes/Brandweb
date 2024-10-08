﻿/*using Brandweb.Models.Domains;
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
    public class OrderDetailsController : ControllerBase
    {
        private readonly UsersDbContext usersDbContext;
        private readonly IConfiguration configuration;

        public OrderDetailsController(UsersDbContext usersDbContext,IConfiguration configuration)
        {
            this.usersDbContext = usersDbContext;
            this.configuration = configuration;
        }
       
        //POST:
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] AddDetailsDto addDetailsDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = await usersDbContext.orderDetails.FirstOrDefaultAsync(c => c.DetailsId == addDetailsDto.DetailsId);
            if (client != null)
            {
                return BadRequest("Already exists");
            }
         

            var DetailsDomainModel = new OrderDetails
            {
                
                Quantity = addDetailsDto.Quantity,
                UnitPrice = addDetailsDto.UnitPrice,
                OrderId = addDetailsDto.OrderId,
               ProductId = addDetailsDto.ProductId,

            };

            usersDbContext.orderDetails.Add(DetailsDomainModel);
            await usersDbContext.SaveChangesAsync();
            
            var UpdateDetailsDto = new DetailsDto
            {
                
                Quantity = DetailsDomainModel.Quantity,
                UnitPrice = DetailsDomainModel.UnitPrice,
                OrderId = DetailsDomainModel.OrderId,
                ProductId = DetailsDomainModel.ProductId,
                

            };

            return Ok($"Details created,{UpdateDetailsDto.OrderId}");
        }
        // GET
        [HttpGet("{DetailsId:int}")]

        public IActionResult GetById(int DetailsId)
        {
            var product = usersDbContext.orderDetails.Find(DetailsId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
       *//* [HttpGet]
        public IActionResult GetAl()
        {
            var products = usersDbContext.orderDetails.ToList();
            return Ok(products);
        }*//*
        [HttpGet]
        public IActionResult GetAll()
        {
            var detailsItems = usersDbContext.orderDetails
                .Include(i => i.Order) // Include the associated ***
                .ToList();

            // Optionally, you can create DTOs to shape the data being returned to the client
            var detailsDtoList = detailsItems.Select(item => new DetailsDto
            {
                OrderId = item.Order.Order_Id,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                ProductId=item.ProductId,

                *//*
                InventoryId = item.InventoryId,
                ProductName = item.Product.Product_Name, // Access product properties
                Quantity = item.Product.Product_Quantity,
                ProductPrice = item.Product.ProductPrice, // Access product properties
                Size = item.Size,
                ProductId = item.ProductId*//*
            }).ToList();

            return Ok(detailsDtoList);
        }







        // PUT: api/Orderdelails/{Product_Id
        [HttpPut("{DetailsId:int}")]
        public IActionResult Update(int DetailsId, [FromBody] AddDetailsDto updateDetailsDto)
        {
            var item = usersDbContext.orderDetails.Find(DetailsId);
            if (item == null)
            {
                return NotFound();
            }

            // Update properties of the existing  entity
            item.Quantity = updateDetailsDto.Quantity;
            item.UnitPrice = updateDetailsDto.UnitPrice;
            item.OrderId = updateDetailsDto.OrderId;
            item.ProductId = updateDetailsDto.ProductId;

          
            // Save the changes to the database
            usersDbContext.SaveChanges();

            // Return the updated  DTO
            var updateddetailsDto = new DetailsDto
            {
                DetailsId=item.DetailsId,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                OrderId = item.OrderId,
                ProductId = item.ProductId,

               
            };

            // Return 200 OK response with the updated  DTO
            return Ok(updateddetailsDto);
        }

        // DELETE: api/Products/{UserId}
        [HttpDelete("{DetailsId:int}")]
        public IActionResult DeleteById(int DetailsId)
        {
            var item = usersDbContext.orderDetails.Find(DetailsId);
            if (item == null)
            {
                return NotFound();
            }

            usersDbContext.orderDetails.Remove(item);
            usersDbContext.SaveChanges();

            return NoContent();
        }
       
    }
}
*/