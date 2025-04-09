using System.ComponentModel.DataAnnotations;

namespace Back.Models
{
    public class GrupoEvaluativo
    {
        public int Id { get; set; }
        public int CicloId { get; set; }

        public string NombreGrupo { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }

        public CicloEvaluativo CicloEvaluativo { get; set; } = null!;
        public ICollection<Evaluacion> Evaluaciones { get; set; } = null!;
    }

}
