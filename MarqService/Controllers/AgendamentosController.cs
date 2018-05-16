using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MarqService.Data;
using MarqService.Models;

namespace MarqService.Controllers
{
    [Produces("application/json")]
    [Route("api/Agendamentos")]
    public class AgendamentosController : Controller
    {
        private readonly MarqServiceContext _context;

        public AgendamentosController(MarqServiceContext context)
        {
            _context = context;
        }

        // GET: api/Agendamentos
        [HttpGet]
        public IEnumerable<Agendamentos> GetAgendamentos()
        {
            return _context.Agendamentos;
        }

        // GET: api/Agendamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgendamentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamentos = await _context.Agendamentos.SingleOrDefaultAsync(m => m.id == id);

            if (agendamentos == null)
            {
                return NotFound();
            }

            return Ok(agendamentos);
        }

        // PUT: api/Agendamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendamentos([FromRoute] int id, [FromBody] Agendamentos agendamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agendamentos.id)
            {
                return BadRequest();
            }

            _context.Entry(agendamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentosExists(id))
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

        // POST: api/Agendamentos
        [HttpPost]
        public async Task<IActionResult> PostAgendamentos([FromBody] Agendamentos agendamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Agendamentos.Add(agendamentos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAgendamentos", new { id = agendamentos.id }, agendamentos);
        }

        // DELETE: api/Agendamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendamentos([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendamentos = await _context.Agendamentos.SingleOrDefaultAsync(m => m.id == id);
            if (agendamentos == null)
            {
                return NotFound();
            }

            _context.Agendamentos.Remove(agendamentos);
            await _context.SaveChangesAsync();

            return Ok(agendamentos);
        }

        private bool AgendamentosExists(int id)
        {
            return _context.Agendamentos.Any(e => e.id == id);
        }
    }
}