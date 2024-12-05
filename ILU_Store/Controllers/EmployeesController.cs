using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILU_Store.Models;
using ILU_Store.Models.Employee;

namespace ILU_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IlustoreContext _context;

        public EmployeesController(IlustoreContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        [Route("Employees")]
        public async Task<ActionResult<IEnumerable<User>>> GetEmployees(int pageNumber = 1, int pageSize = 10)
        {
            var employees = await _context.Users.Where(e => e.Role.Name == "Employee")
                                                .Include(e => e.Addresses)
                                                .Skip((pageNumber - 1) * pageSize)
                                                .Take(pageSize)
                                                .ToListAsync();
            return Ok(employees);
        }
     
        [HttpGet("Search/{keyword}")]
        public async Task<ActionResult<IEnumerable<User>>> Search(int pageNumber = 1, int pageSize = 10, string keyword = "")
        {

            var query = _context.Users.Where(e => e.Role.Name == "Employee");

            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(e => e.FullName.Contains(keyword) ||
                                          e.Email.Contains(keyword) ||
                                          e.Username.Contains(keyword));
            }

            var employees = await query
                .Include(e => e.Addresses)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(employees);
        }


        [HttpGet("GetEmployeeByID/{id}")]
        public async Task<ActionResult<User>> GetEmployeeByID(int id)
        {
            var user = await _context.Users
                                    .Include(e => e.Addresses)
                                    .FirstOrDefaultAsync(u => u.UserId == id);
            if (user == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(user);
        }


       
        [HttpPut("UpdateByAdmin/{id}")]
 
        public async Task<IActionResult> UpdateEmployeeByAdmin(int id, UpdateEmployeeModel model)
        {
            var employee = await _context.Users.FirstOrDefaultAsync(u=>u.UserId==id);

            employee.Status= model.Status;
            employee.RoleId = model.RoleId;

            await _context.SaveChangesAsync();
            return Ok("Update successfully");
        }

        
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<User>> CreateEmployee(CreateEmployeeModel model)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Username == model.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists.");
            }

            var employee = new User
            {
                Username = model.Username,
                Password = model.Password,
                RoleId = model.RoleId
            };
            _context.Users.Add(employee);
            await _context.SaveChangesAsync();
            return Ok("Created successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok("Delete successfully");
        }

    }
}
