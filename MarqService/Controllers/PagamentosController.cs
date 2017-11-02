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
    [Route("api/Pagamentos")]
    public class PagamentosController : Controller
    {
        private readonly MarqServiceContext _context;

        public PagamentosController(MarqServiceContext context)
        {
            _context = context;
        }

        // GET: api/Pagamentos
        [HttpGet]
        public IEnumerable<Pagamentos> GetPagamentos()
        {
            return _context.Pagamentos;
        }

        // GET: api/Pagamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPagamentos([FromRoute] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagamentos = await _context.Pagamentos.SingleOrDefaultAsync(m => m.DataPagamento == id);

            if (pagamentos == null)
            {
                return NotFound();
            }

            return Ok(pagamentos);
        }

        // PUT: api/Pagamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPagamentos([FromRoute] DateTime id, [FromBody] Pagamentos pagamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pagamentos.DataPagamento)
            {
                return BadRequest();
            }

            _context.Entry(pagamentos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagamentosExists(id))
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

        // POST: api/Pagamentos
        [HttpPost]
        public async Task<IActionResult> PostPagamentos([FromBody] Pagamentos pagamentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Pagamentos.Add(pagamentos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PagamentosExists(pagamentos.DataPagamento))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPagamentos", new { id = pagamentos.DataPagamento }, pagamentos);
        }

        // DELETE: api/Pagamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePagamentos([FromRoute] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var pagamentos = await _context.Pagamentos.SingleOrDefaultAsync(m => m.DataPagamento == id);
            if (pagamentos == null)
            {
                return NotFound();
            }

            _context.Pagamentos.Remove(pagamentos);
            await _context.SaveChangesAsync();

            return Ok(pagamentos);
        }

        private bool PagamentosExists(DateTime id)
        {
            return _context.Pagamentos.Any(e => e.DataPagamento == id);
        }
    }
}