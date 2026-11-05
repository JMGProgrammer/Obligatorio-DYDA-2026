namespace Reporteros.Api.Models
{
    public class Temporada
    {
        public long Id { get; set; }
        public long CompeticionId { get; set; }
        public string Etiqueta { get; set; } = string.Empty;
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Estado { get; set; } = "borrador";
        public string? ReglasJson { get; set; }

        public Competicion Competicion { get; set; } = null!;
        public ICollection<Partido> Partidos { get; set; } = new List<Partido>();
        public ICollection<EquipoTemporada> EquiposTemporada { get; set; } = new List<EquipoTemporada>();
    }
}
