﻿using brand.Data;
using Brandweb.Models.Domains;
using Brandweb.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

using User.Models.Dto;

namespace Brandweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private readonly brandDbContext _context;

        public UserLoginController(brandDbContext dbcontext)
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
            if (_context.user.Any(u => u.Email == addUsersDto.Email))
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

            _context.user.Add(clientPrivacy);
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

            var use = await _context.user.FirstOrDefaultAsync(c => c.Email == request.Email);
            if (use == null)
            {
                return BadRequest("User Not Found");
            }
            if (!VerifypasswordHash(request.Password, use.PasswordHash, use.PasswordSalt))
            {
                return BadRequest("Password is Incorrect");
            }
           
            return Ok($"Welcome Back, {use.UserName} ,{use.Email} :");

        }
        [HttpGet("getAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _context.user.ToList();
            var userDtos = new List<UsersDto>();

            foreach (var user in users)
            {
                userDtos.Add(new UsersDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Id=user.Id,
                });
            }

            return Ok(userDtos);
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
