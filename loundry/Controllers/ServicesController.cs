using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swagger_loundry.models;

namespace loundry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "1")]
    public class ServicesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ServicesController(ApplicationDBContext context)
        {
            _context = context;
        }

        //[Authorize(Roles = "0")]
        // GET: api/Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Services>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        //[Authorize(Roles = "0")]
        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Services>> GetServices(string id)
        {
            var services = await _context.Services.FindAsync(id);

            if (services == null)
            {
                return NotFound();
            }

            return services;
        }

        // PUT: api/Services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServices(string id, Services services)
        {
            if (id != services.Id)
            {
                return BadRequest();
            }

            _context.Entry(services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Services>> PostServices(Services services)
        {
            _context.Services.Add(services);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServices", new { id = services.Id }, services);
        }

        // DELETE: api/Services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServices(string id)
        {
            var services = await _context.Services.FindAsync(id);
            if (services == null)
            {
                return NotFound();
            }

            _context.Services.Remove(services);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServicesExists(string id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
