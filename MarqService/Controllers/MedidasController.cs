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
    [Route("api/Medidas")]
    public class MedidasController : Controller
    {
        private readonly MarqServiceContext _context;

        public MedidasController(MarqServiceContext context)
        {
            _context = context;
        }

        // GET: api/Medidas
        [HttpGet]
        public IEnumerable<Medida> GetMedida()
        {
            return _context.Medida;
        }

        // GET: api/Medidas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedida([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medida = await _context.Medida.SingleOrDefaultAsync(m => m.IdMedida == id);

            if (medida == null)
            {
                return NotFound();
            }

            return Ok(medida);
        }

        // PUT: api/Medidas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedida([FromRoute] int id, [FromBody] Medida medida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != medida.IdMedida)
            {
                return BadRequest();
            }

            _context.Entry(medida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedidaExists(id))
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

        // POST: api/Medidas
        [HttpPost]
        public async Task<IActionResult> PostMedida([FromBody] Medida medida)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Medida.Add(medida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMedida", new { id = medida.IdMedida }, medida);
        }

        // DELETE: api/Medidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedida([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var medida = await _context.Medida.SingleOrDefaultAsync(m => m.IdMedida == id);
            if (medida == null)
            {
                return NotFound();
            }

            _context.Medida.Remove(medida);
            await _context.SaveChangesAsync();

            return Ok(medida);
        }

        private bool MedidaExists(int id)
        {
            return _context.Medida.Any(e => e.IdMedida == id);
        }
    }
}