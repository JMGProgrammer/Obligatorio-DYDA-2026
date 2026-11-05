namespace Reporteros.Api.Models
{
    public class Equipo
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? UrlLogo { get; set; }

        public ICollection<EquipoTemporada> EquiposTemporada { get; set; } = new List<EquipoTemporada>();
        public ICollection<Partido> PartidosLocal { get; set; } = new List<Partido>();
        public ICollection<Partido> PartidosVisitante { get; set; } = new List<Partido>();
    }
}
