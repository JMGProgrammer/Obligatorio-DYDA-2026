namespace Reporteros.Api.Models
{
    public class EquipoTemporada
    {
        public long Id { get; set; }
        public long TemporadaId { get; set; }
        public long EquipoId { get; set; }

        public Temporada Temporada { get; set; } = null!;
        public Equipo Equipo { get; set; } = null!;
    }
}
