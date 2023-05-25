using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareLogAnalizer.Client.Pages.Employees;
using SoftwareLogAnalizer.Server;
using SoftwareLogAnalizer.Shared.Model;

namespace SoftwareLogAnalizer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ResourcesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Resources
        [HttpGet]
        [Route("GetResources")]
        public async Task<ActionResult<IEnumerable<Resource>>> GetResources()
        {
          if (_context.Resources == null)
          {
              return NotFound();
          }
            return await _context.Resources.ToListAsync();
        }

        // GET: api/Resources/5
        [HttpGet("{id}")]
        [Route("GetResource")]
        public async Task<ActionResult<Resource>> GetResource(int id)
        {
          if (_context.Resources == null)
          {
              return NotFound();
          }
            var resource = await _context.Resources.FindAsync(id);

            if (resource == null)
            {
                return NotFound();
            }

            return resource;
        }

        // PUT: api/Resources/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("PutResource")]
        public async Task<IActionResult> PutResource(Resource resource)
        {
            _context.Entry(resource).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Resources
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostResource")]
        public async Task<ActionResult<Resource>> PostResource(Resource resource)
        {
          if (_context.Resources == null)
          {
              return Problem("Entity set 'AppDbContext.Resources'  is null.");
          }
            _context.Resources.Add(resource);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResource", new { id = resource.Id }, resource);
        }

        // DELETE: api/Resources/5
        [HttpDelete("{id}")]
        [Route("DeleteResource/{id}")]
        public async Task<IActionResult> DeleteResource(int id)
        {
            if (_context.Resources == null)
            {
                return NotFound();
            }
            var resource = await _context.Resources.FindAsync(id);
            if (resource == null)
            {
                return NotFound();
            }

            _context.Resources.Remove(resource);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResourceExists(int id)
        {
            return (_context.Resources?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
