using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarqService.Models;
using MarqService.Data;

namespace MarqService.Controllers
{
    [Produces("application/json")]
    [Route("api/Anamnese")]
    public class AnamneseController : Controller
    {
        private readonly MarqServiceContext _context;

        public AnamneseController(MarqServiceContext context)
        {
            _context = context;
        }

        // GET: api/Anamnese
        [HttpGet]
        public IEnumerable<Anamnese> GetAnamnese()
        {
            return _context.Anamnese;
        }

        // GET: api/Anamnese/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnamnese([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anamnese = await _context.Anamnese.SingleOrDefaultAsync(m => m.IdAnamnese == id);

            if (anamnese == null)
            {
                return NotFound();
            }

            return Ok(anamnese);
        }

        // PUT: api/Anamnese/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnamnese([FromRoute] int id, [FromBody] Anamnese anamnese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != anamnese.IdAnamnese)
            {
                return BadRequest();
            }

            _context.Entry(anamnese).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnamneseExists(id))
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

        // POST: api/Anamnese
        [HttpPost]
        public async Task<IActionResult> PostAnamnese([FromBody] Anamnese anamnese)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Anamnese.Add(anamnese);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnamnese", new { id = anamnese.IdAnamnese }, anamnese);
        }

        // DELETE: api/Anamnese/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnamnese([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var anamnese = await _context.Anamnese.SingleOrDefaultAsync(m => m.IdAnamnese == id);
            if (anamnese == null)
            {
                return NotFound();
            }

            _context.Anamnese.Remove(anamnese);
            await _context.SaveChangesAsync();

            return Ok(anamnese);
        }

        private bool AnamneseExists(int id)
        {
            return _context.Anamnese.Any(e => e.IdAnamnese == id);
        }
    }
}