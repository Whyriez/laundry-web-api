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
    public class DepositsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public DepositsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Deposits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Deposits>>> GetDeposits()
        {
            return await _context.Deposits.ToListAsync();
        }

        // GET: api/Deposits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Deposits>> GetDeposits(string id)
        {
            var deposits = await _context.Deposits.FindAsync(id);

            if (deposits == null)
            {
                return NotFound();
            }

            return deposits;
        }

        

        // POST: api/Deposits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Deposits>> PostDeposits(Deposits deposits)
        {
            _context.Deposits.Add(deposits);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeposits", new { id = deposits.Id }, deposits);
        }

       
        private bool DepositsExists(string id)
        {
            return _context.Deposits.Any(e => e.Id == id);
        }
    }
}
