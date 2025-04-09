using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CicloEvaluativoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CicloEvaluativoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CicloEvaluativo>>> GetCiclosEvaluativos()
        {
            return await _context.CiclosEvaluativos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CicloEvaluativo>> GetCicloEvaluativo(int id)
        {
            var ciclo = await _context.CiclosEvaluativos.FindAsync(id);
            if (ciclo == null) return NotFound();
            return ciclo;
        }

        [HttpPost]
        public async Task<ActionResult<CicloEvaluativo>> PostCicloEvaluativo(CicloEvaluativo ciclo)
        {
            _context.CiclosEvaluativos.Add(ciclo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCicloEvaluativo), new { id = ciclo.Id }, ciclo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCicloEvaluativo(int id, CicloEvaluativo ciclo)
        {
            if (id != ciclo.Id) return BadRequest();
            _context.Entry(ciclo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCicloEvaluativo(int id)
        {
            var ciclo = await _context.CiclosEvaluativos.FindAsync(id);
            if (ciclo == null) return NotFound();
            _context.CiclosEvaluativos.Remove(ciclo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
