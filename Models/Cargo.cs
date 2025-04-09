using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Cargo
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public ICollection<Empleado> Empleados { get; set; } = null!;
        public ICollection<Cuestionario> Cuestionarios { get; set; } = null!;
    }
}
