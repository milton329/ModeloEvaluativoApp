using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CuestionarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CuestionarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cuestionario>>> GetCuestionarios()
        {
            return await _context.Cuestionarios.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cuestionario>> GetCuestionario(int id)
        {
            var cuestionario = await _context.Cuestionarios.FindAsync(id);
            if (cuestionario == null) return NotFound();
            return cuestionario;
        }

        [HttpPost]
        public async Task<ActionResult<Cuestionario>> PostCuestionario(Cuestionario cuestionario)
        {
            _context.Cuestionarios.Add(cuestionario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCuestionario), new { id = cuestionario.Id }, cuestionario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCuestionario(int id, Cuestionario cuestionario)
        {
            if (id != cuestionario.Id) return BadRequest();
            _context.Entry(cuestionario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCuestionario(int id)
        {
            var cuestionario = await _context.Cuestionarios.FindAsync(id);
            if (cuestionario == null) return NotFound();
            _context.Cuestionarios.Remove(cuestionario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
