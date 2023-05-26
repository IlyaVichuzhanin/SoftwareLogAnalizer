using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareLogAnalizer.Server;
using SoftwareLogAnalizer.Shared.Model;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoftwareLogAnalizer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        [Route("GetEmployees")]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            //var companies = _context.Companies.ToList();
            //var resources = _context.Resources.ToList();

                if (_context.Employees == null)
                {
                    return NotFound();
                }
                var employes = await _context.Employees
                      .Include(e => e.Company)
                      .Include(e => e.Resource)
                      .ToListAsync();
                return employes;
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        [Route("GetEmployee")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employee = await _context.Employees
                //.Include(e=>e.Company)
                //.Include(e => e.Resource)
                .FirstOrDefaultAsync(e=>e.Id==id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("PutEmployee")]
        public async Task<IActionResult> PutEmployee(Employee employee)
        {
            
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostEmployee")]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            if (_context.Employees == null)
          {
              return Problem("Entity set 'AppDbContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        [Route("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
