using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Back.Models;
using System;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoEvaluativoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GrupoEvaluativoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrupoEvaluativo>>> GetGrupoEvaluativos()
        {
            return await _context.GrupoEvaluativos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoEvaluativo>> GetGrupoEvaluativo(int id)
        {
            var grupo = await _context.GrupoEvaluativos.FindAsync(id);
            if (grupo == null) return NotFound();
            return grupo;
        }

        [HttpPost]
        public async Task<ActionResult<GrupoEvaluativo>> PostGrupoEvaluativo(GrupoEvaluativo grupo)
        {
            _context.GrupoEvaluativos.Add(grupo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetGrupoEvaluativo), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrupoEvaluativo(int id, GrupoEvaluativo grupo)
        {
            if (id != grupo.Id) return BadRequest();
            _context.Entry(grupo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoEvaluativo(int id)
        {
            var grupo = await _context.GrupoEvaluativos.FindAsync(id);
            if (grupo == null) return NotFound();
            _context.GrupoEvaluativos.Remove(grupo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
