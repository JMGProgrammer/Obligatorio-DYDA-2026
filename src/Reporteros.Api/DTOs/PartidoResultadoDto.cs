namespace Reporteros.Api.DTOs
{
    public class PartidoResultadoDto
    {
        public int PuntosLocal { get; set; }
        public int PuntosVisitante { get; set; }
        public string Estado { get; set; } = "finalizado";
        public int Version { get; set; }
        public string Motivo { get; set; } = string.Empty;
    }
}
