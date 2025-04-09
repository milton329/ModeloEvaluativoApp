using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class Pregunta
    {
        public int Id { get; set; }
        public int CuestionarioId { get; set; }
        public string TextoPregunta { get; set; } = string.Empty;

        public Cuestionario Cuestionario { get; set; } = null!;
        public ICollection<Respuesta> Respuestas { get; set; } = null!;
    }

}
