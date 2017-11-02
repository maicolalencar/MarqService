using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarqService.Models;
using MarqService.Data;

namespace MarqService.Models
{
    [Produces("application/json")]
    [Route("api/Massagens")]
    public class MassagensController : Controller
    {
        private readonly MarqServiceContext _context;

        public MassagensController(MarqServiceContext context)
        {
            _context = context;
        }

        // GET: api/Massagens
        [HttpGet]
        public IEnumerable<Massagens> GetMassagens()
        {
            return _context.Massagens;
        }

        // GET: api/Massagens/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMassagens([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var massagens = await _context.Massagens.SingleOrDefaultAsync(m => m.IdMassagem == id);

            if (massagens == null)
            {
                return NotFound();
            }

            return Ok(massagens);
        }

        // PUT: api/Massagens/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMassagens([FromRoute] int id, [FromBody] Massagens massagens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != massagens.IdMassagem)
            {
                return BadRequest();
            }

            _context.Entry(massagens).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MassagensExists(id))
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

        // POST: api/Massagens
        [HttpPost]
        public async Task<IActionResult> PostMassagens([FromBody] Massagens massagens)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Massagens.Add(massagens);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMassagens", new { id = massagens.IdMassagem }, massagens);
        }

        // DELETE: api/Massagens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMassagens([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var massagens = await _context.Massagens.SingleOrDefaultAsync(m => m.IdMassagem == id);
            if (massagens == null)
            {
                return NotFound();
            }

            _context.Massagens.Remove(massagens);
            await _context.SaveChangesAsync();

            return Ok(massagens);
        }

        private bool MassagensExists(int id)
        {
            return _context.Massagens.Any(e => e.IdMassagem == id);
        }
    }
}