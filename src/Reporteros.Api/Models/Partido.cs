namespace Reporteros.Api.Models
{
    public class Partido
    {
        public long Id { get; set; }
        public long TemporadaId { get; set; }
        public long EquipoLocalId { get; set; }
        public long EquipoVisitanteId { get; set; }
        public DateTime ProgramadoEn { get; set; }
        public string Estado { get; set; } = "programado";
        public int? PuntosLocal { get; set; }
        public int? PuntosVisitante { get; set; }
        public int? MejorDe { get; set; }
        public long? FuenteId { get; set; }
        public int Version { get; set; } = 1;
        public DateTime? PublicadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;

        public Temporada Temporada { get; set; } = null!;
        public Equipo EquipoLocal { get; set; } = null!;
        public Equipo EquipoVisitante { get; set; } = null!;
        public Fuente? Fuente { get; set; }
        public ICollection<EventoPartido> Eventos { get; set; } = new List<EventoPartido>();
        public ICollection<RevisionResultado> Revisiones { get; set; } = new List<RevisionResultado>();
    }
}
