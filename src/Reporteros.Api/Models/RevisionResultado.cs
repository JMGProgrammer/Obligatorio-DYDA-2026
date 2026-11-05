namespace Reporteros.Api.Models
{
    public class RevisionResultado
    {
        public long Id { get; set; }
        public long PartidoId { get; set; }
        public long EditorUsuarioId { get; set; }
        public string AnteriorJson { get; set; } = string.Empty;
        public string NuevoJson { get; set; } = string.Empty;
        public string Motivo { get; set; } = string.Empty;
        public DateTime CambiadoEn { get; set; } = DateTime.UtcNow;

        public Partido Partido { get; set; } = null!;
        public Usuario Editor { get; set; } = null!;
    }
}
