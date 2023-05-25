using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Elfie.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareLogAnalizer.Server;
using SoftwareLogAnalizer.Shared.Model;

namespace SoftwareLogAnalizer.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SoftwaresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SoftwaresController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Softwares
        [HttpGet]
        [Route("GetSoftwares")]
        public async Task<ActionResult<IEnumerable<Software>>> GetSoftwares()
        {
          if (_context.Softwares == null)
          {
              return NotFound();
          }
            return await _context.Softwares.ToListAsync();
        }

        // GET: api/Softwares/5
        [HttpGet("{id}")]
        [Route("GetSoftware")]
        public async Task<ActionResult<Software>> GetSoftware(int id)
        {
          if (_context.Softwares == null)
          {
              return NotFound();
          }
            var software = await _context.Softwares.FindAsync(id);

            if (software == null)
            {
                return NotFound();
            }

            return software;
        }

        // PUT: api/Softwares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Route("PutSoftware")]
        public async Task<IActionResult> PutSoftware(Software software)
        {
            _context.Entry(software).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // POST: api/Softwares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Route("PostSoftware")]
        public async Task<ActionResult<Software>> PostSoftware(Software software)
        {
          if (_context.Softwares == null)
          {
              return Problem("Entity set 'AppDbContext.Softwares'  is null.");
          }
            _context.Softwares.Add(software);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoftware", new { id = software.Id }, software);
        }

        // DELETE: api/Softwares/5
        [HttpDelete("{id}")]
        [Route("DeleteSoftware/{id}")]
        public async Task<IActionResult> DeleteSoftware(int id)
        {
            if (_context.Softwares == null)
            {
                return NotFound();
            }
            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }

            _context.Softwares.Remove(software);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SoftwareExists(int id)
        {
            return (_context.Softwares?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
