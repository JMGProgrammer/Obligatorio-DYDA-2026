namespace Reporteros.Api.Models
{
    public class EventoPartido
    {
        public long Id { get; set; }
        public long PartidoId { get; set; }
        public string TipoEvento { get; set; } = string.Empty;
        public string? MinutoORonda { get; set; }
        public string? MetadatosJson { get; set; }

        public Partido Partido { get; set; } = null!;
    }
}
