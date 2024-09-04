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
    //[Authorize(Roles = "1, 2")]
    public class PackageTransactionsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PackageTransactionsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/PackageTransactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PackageTransactions>>> GetPackageTransactions()
        {
            return await _context.PackageTransactions.ToListAsync();
        }

        // GET: api/PackageTransactions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PackageTransactions>> GetPackageTransactions(string id)
        {
            var packageTransactions = await _context.PackageTransactions.FindAsync(id);

            if (packageTransactions == null)
            {
                return NotFound();
            }

            return packageTransactions;
        }

        // PUT: api/PackageTransactions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       

        // POST: api/PackageTransactions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PackageTransactions>> PostPackageTransactions(PackageTransactions packageTransactions)
        {
            _context.PackageTransactions.Add(packageTransactions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackageTransactions", new { id = packageTransactions.Id }, packageTransactions);
        }

      

        private bool PackageTransactionsExists(string id)
        {
            return _context.PackageTransactions.Any(e => e.Id == id);
        }
    }
}
