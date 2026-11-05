namespace Reporteros.Api.Models
{
    public class RegistroAuditoria
    {
        public long Id { get; set; }
        public long ActorUsuarioId { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string TipoEntidad { get; set; } = string.Empty;
        public long EntidadId { get; set; }
        public DateTime OcurridoEn { get; set; } = DateTime.UtcNow;
        public string? DetallesJson { get; set; }

        public Usuario Actor { get; set; } = null!;
    }
}
