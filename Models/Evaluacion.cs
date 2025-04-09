using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Evaluacion
    {
        public int Id { get; set; }

        public int EmpleadoEvaluadoId { get; set; }
        public int EmpleadoEvaluadorId { get; set; }
        public int GrupoEvaluativoId { get; set; }
        public int CuestionarioId { get; set; }

        public DateTime Fecha { get; set; }
        public bool Finalizada { get; set; }
            
        public Empleado EmpleadoEvaluado { get; set; } = null!;     
        public Empleado EmpleadoEvaluador { get; set; } = null!;
        public GrupoEvaluativo GrupoEvaluativo { get; set; } = null!;
        public Cuestionario Cuestionario { get; set; } = null!;

        public ICollection<Respuesta> Respuestas { get; set; } = null!;
    }

}
