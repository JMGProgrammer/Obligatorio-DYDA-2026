namespace Reporteros.Api.DTOs
{
    public class TemporadaCreacionDto
    {
        public long CompeticionId { get; set; }
        public string Etiqueta { get; set; } = string.Empty;
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Estado { get; set; } = "borrador";
        public string? ReglasJson { get; set; }
    }
}
