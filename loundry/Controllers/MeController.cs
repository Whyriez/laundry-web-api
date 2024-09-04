using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swagger_loundry.models;

namespace loundry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "1")]
    public class MeController : ControllerBase
    {
        public static IWebHostEnvironment _webHostEnvironment;
        private readonly ApplicationDBContext _context;

        public MeController(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("Photo")]
        public async Task<string> Post([FromForm] Photo fileUpload)
        {
            try
            {
                if (fileUpload.files.Length > 0)
                {
                    string path = _webHostEnvironment.WebRootPath + "\\Photo\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.files.FileName))
                    {
                        fileUpload.files.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Upload Done.";
                    }
                }
                else
                {
                    return "Failed";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> Get([FromRoute] string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Photo\\";
            var filepath = path + fileName + ".png || .jpg || .jpeg";
            if (System.IO.File.Exists(filepath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filepath);
                return File(b, "image/png || image/jpg || image/jpeg");
            }
            return null;
        }

        // GET: api/Me
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetMe()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Me/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Me>> GetMe(string id)
        {
            var me = await _context.Me.FindAsync(id);

            if (me == null)
            {
                return NotFound();
            }

            return me;
        }

        // PUT: api/Me/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMe(string id, Me me)
        {
            if (id != me.Email)
            {
                return BadRequest();
            }

            _context.Entry(me).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MeExists(id))
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

        // POST: api/Me
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Me>> PostMe(Me me)
        {
            _context.Me.Add(me);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMe", new { id = me.Email }, me);
        }

       
        private bool MeExists(string id)
        {
            return _context.Me.Any(e => e.Email == id);
        }
    }
}
