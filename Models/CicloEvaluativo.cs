using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class CicloEvaluativo
    {
        public int Id { get; set; }
        public int Año { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public ICollection<GrupoEvaluativo> GruposEvaluativos { get; set; } = null!;
    }

}
