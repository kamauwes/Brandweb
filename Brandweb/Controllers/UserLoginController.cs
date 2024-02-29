using Brandweb.Models.Domains;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using User.Data;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly UsersDbContext _context;

        public UserLoginController(UsersDbContext dbcontext)
        {
            _context = dbcontext;
        }
        [HttpPost("Signup")]
        public async Task<IActionResult> Register([FromBody] AddUsersDto addUsersDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (_context.Customers.Any(u => u.Email == addUsersDto.Email))
            {
                return BadRequest("User Exists Already");
            }
            CreatepasswordHash(addUsersDto.Password,
                out byte[] passwordHash,
                out byte[] passwordsalt);




            var clientPrivacy = new Customer
            {
                UserName = addUsersDto.UserName,
                Email = addUsersDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordsalt,
                VerificationToken = CreateRandomToken()
            };

            _context.Customers.Add(clientPrivacy);
            await _context.SaveChangesAsync();

            /* var clientDto = new ClientDto
             {
                 Id = clientPrivacy.Id,
                 UserName = clientPrivacy.UserName,
                 Email = clientPrivacy.Email,
                 PasswordHash=clientPrivacy.PasswordHash,
                 PasswordSalt=clientPrivacy.PasswordSalt
             };*/

            return Ok("User Signup created");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin request)
        {

            var use = await _context.Customers.FirstOrDefaultAsync(c => c.Email == request.Email);
            if (use == null)
            {
                return BadRequest("User Not Found");
            }
            if (!VerifypasswordHash(request.Password, use.PasswordHash, use.PasswordSalt))
            {
                return BadRequest("Password is Incorrect");
            }
            /* if (use.VerifiedAt == null)
             {
                 return BadRequest("Not verified");
             }
            */

            return Ok($"Welcome Back, {use.UserName} ,{use.Email} :");

        }
        /* [HttpPost("Verify")]
         public async Task<IActionResult> Verify(string token)
         {

             var use = await _context.UserPrivacy.FirstOrDefaultAsync(c => c.VerificationToken == token);
             if (use == null)
             {
                 return BadRequest("Invalid Token");
             }
              use.VerifiedAt=DateTime.Now;
             await _context.SaveChangesAsync();
             return Ok("User Verified");

         }*/



        private void CreatepasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifypasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var ComputedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return ComputedHash.SequenceEqual(passwordHash);
            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(32));
        }
    }
}
