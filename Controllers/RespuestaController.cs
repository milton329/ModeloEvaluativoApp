using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RespuestaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetRespuestas()
        {
            var respuestas = await _context.Respuestas
                .Include(r => r.Pregunta)
                .Include(r => r.Evaluacion)
                .Select(r => new
                {
                    r.Id,
                    r.Contenido,
                    r.PreguntaId,
                    TextoPregunta = r.Pregunta.Texto,
                    r.EvaluacionId,
                    NombreEvaluacion = r.Evaluacion.Nombre
                })
                .ToListAsync();

            return Ok(respuestas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetRespuesta(int id)
        {
            var respuesta = await _context.Respuestas
                .Include(r => r.Pregunta)
                .Include(r => r.Evaluacion)
                .Where(r => r.Id == id)
                .Select(r => new
                {
                    r.Id,
                    r.Contenido,
                    r.PreguntaId,
                    TextoPregunta = r.Pregunta.Texto,
                    r.EvaluacionId,
                    NombreEvaluacion = r.Evaluacion.Nombre
                })
                .FirstOrDefaultAsync();

            if (respuesta == null) return NotFound();
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<ActionResult<Respuesta>> PostRespuesta(Respuesta respuesta)
        {
            _context.Respuestas.Add(respuesta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRespuesta), new { id = respuesta.Id }, respuesta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuesta(int id, Respuesta respuesta)
        {
            if (id != respuesta.Id) return BadRequest();
            _context.Entry(respuesta).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuesta(int id)
        {
            var respuesta = await _context.Respuestas.FindAsync(id);
            if (respuesta == null) return NotFound();
            _context.Respuestas.Remove(respuesta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
