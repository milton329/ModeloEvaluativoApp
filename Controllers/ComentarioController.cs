using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComentarioController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetComentarios()
        {
            var comentarios = await _context.Comentarios
                .Include(c => c.Empleado)
                .Include(c => c.Evaluacion)
                .Include(c => c.Pregunta)
                .Select(c => new
                {
                    c.Id,
                    c.Texto,
                    c.EmpleadoId,
                    NombreEmpleado = c.Empleado.Nombre,
                    c.EvaluacionId,
                    c.PreguntaId,
                    TextoPregunta = c.Pregunta.Texto
                })
                .ToListAsync();

            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetComentario(int id)
        {
            var comentario = await _context.Comentarios
                .Include(c => c.Empleado)
                .Include(c => c.Evaluacion)
                .Include(c => c.Pregunta)
                .Where(c => c.Id == id)
                .Select(c => new
                {
                    c.Id,
                    c.Texto,
                    c.EmpleadoId,
                    NombreEmpleado = c.Empleado.Nombre,
                    c.EvaluacionId,
                    c.PreguntaId,
                    TextoPregunta = c.Pregunta.Texto
                })
                .FirstOrDefaultAsync();

            if (comentario == null) return NotFound();

            return Ok(comentario);
        }

        [HttpPost]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {
            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            if (id != comentario.Id) return BadRequest();
            _context.Entry(comentario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null) return NotFound();
            _context.Comentarios.Remove(comentario);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
