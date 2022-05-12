using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repunsitory.Server.Data;
using Repunsitory.Shared.Models;

namespace Repunsitory.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PunsController : ControllerBase
    {
        private readonly RepunsitoryContext _context;

        public PunsController(RepunsitoryContext context)
        {
            _context = context;
        }

        // GET: api/Puns
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pun>>> GetPun()
        {
          if (_context.Pun == null)
          {
              return NotFound();
          }
            return await _context.Pun.ToListAsync();
        }

        // GET: api/Puns/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pun>> GetPun(int id)
        {
          if (_context.Pun == null)
          {
              return NotFound();
          }
            var pun = await _context.Pun.FindAsync(id);

            if (pun == null)
            {
                return NotFound();
            }

            return pun;
        }

        // PUT: api/Puns/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPun(int id, Pun pun)
        {
            if (id != pun.Id)
            {
                return BadRequest();
            }

            _context.Entry(pun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PunExists(id))
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

        // POST: api/Puns
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pun>> PostPun(Pun pun)
        {
          if (_context.Pun == null)
          {
              return Problem("Entity set 'RepunsitoryContext.Pun'  is null.");
          }
            _context.Pun.Add(pun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPun", new { id = pun.Id }, pun);
        }

        // DELETE: api/Puns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePun(int id)
        {
            if (_context.Pun == null)
            {
                return NotFound();
            }
            var pun = await _context.Pun.FindAsync(id);
            if (pun == null)
            {
                return NotFound();
            }

            _context.Pun.Remove(pun);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PunExists(int id)
        {
            return (_context.Pun?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
