using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class ModeloEvaluativo
    {
        public int Id { get; set; }
        public string NombreModelo { get; set; } = string.Empty;

        public ICollection<Cuestionario> Cuestionarios { get; set; } = null!;

    }
}
