using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Cuestionario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;

        public int CargoId { get; set; }
        public int ModeloEvaluativoId { get; set; }

        public Cargo Cargo { get; set; }
        public ModeloEvaluativo ModeloEvaluativo { get; set; } = null!;

        public ICollection<Pregunta> Preguntas { get; set; }    = null!;
        public ICollection<Evaluacion> Evaluaciones { get; set; } = null!;
    }

}
