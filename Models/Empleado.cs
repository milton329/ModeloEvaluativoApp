using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int CargoId { get; set; }
        public int? JefeId { get; set; } = null!;
        public string Email { get; set; } = string.Empty;

        public Cargo Cargo { get; set; } = null!;
        public Empleado? Jefe { get; set; } = null!;
        public ICollection<Evaluacion> EvaluacionesRealizadas { get; set; } = null!;
        public ICollection<Evaluacion> EvaluacionesRecibidas { get; set; }  = null!;
    }

}
