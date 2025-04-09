using Back.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Back.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetEmpleados()
        {
            var empleados = await _context.Empleados
                .Include(e => e.Cargo)
                .Select(e => new
                {
                    e.Id,
                    e.Nombre,
                    e.Edad,
                    e.CargoId,
                    NombreCargo = e.Cargo.Nombre
                })
                .ToListAsync();

            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados
                .Include(e => e.Cargo)
                .Where(e => e.Id == id)
                .Select(e => new
                {
                    e.Id,
                    e.Nombre,
                    e.Edad,
                    e.CargoId,
                    NombreCargo = e.Cargo.Nombre
                })
                .FirstOrDefaultAsync();

            if (empleado == null) return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest();
            _context.Entry(empleado).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null) return NotFound();
            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
