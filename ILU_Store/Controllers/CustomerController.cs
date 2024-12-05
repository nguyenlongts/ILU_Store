using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILU_Store.Models;
using ILU_Store.DTOs;

namespace ILU_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IlustoreContext _context;

        public CustomerController(IlustoreContext context)
        {
            _context = context;
        }

      
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<User>>> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            var customers = await _context.Users.Where(e => e.Role.Name == "Customer")
                                               .Include(e => e.Addresses)
                                               .Skip((pageNumber - 1) * pageSize)
                                               .Take(pageSize)
                                               .ToListAsync();
            return Ok(customers);
        }

        
        [HttpGet("GetByID/{id}")]
        public async Task<ActionResult> GetUserDetail(int id)
        {
            var user = await _context.Users
                .Where(u => u.UserId == id)
                 .Include(u => u.Role)
                .Select(u => new UserDTO {   
                    UserId = u.UserId,
                    Username = u.Username,
                    Password = u.Password,
                    Email = u.Email,
                    Phone = u.Phone,
                    
                    Status = u.Status,
                    DoB = u.DoB,
                    Gender = u.Gender,
                    FullName = u.FullName,
                    Addresses = u.Addresses.Select(a => new AddressDTO
                    {
                        Address = a.AddressName,
                        DefaultAddress = a.DefaultAddress,
                    }).ToList(),
                    Role = u.Role.Name 
             }).FirstOrDefaultAsync();
             if (user == null)
                {
                    return NotFound();
                }

             return Ok(user);
        }

[HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User model)
        {
            var customer = await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);

            customer.Status = model.Status;
            customer.RoleId = model.RoleId;

            await _context.SaveChangesAsync();
            return Ok("Update successfully");
        }

   
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Không tìm thấy người dùng");
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully");
        }

    }
}
