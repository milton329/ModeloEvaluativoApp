using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Respuesta
    {
        public int Id { get; set; }

        public int EvaluacionId { get; set; }
        public int PreguntaId { get; set; }
        public int Calificacion { get; set; } // De 1 a 5
        public string? Comentario { get; set; }

        public Evaluacion Evaluacion { get; set; } = null!;
        public Pregunta Pregunta { get; set; } = null!;
    }

}
