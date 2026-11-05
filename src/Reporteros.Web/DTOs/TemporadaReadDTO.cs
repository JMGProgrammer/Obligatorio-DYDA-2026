namespace Reporteros.Web.DTOs
{
    public class TemporadaReadDTO
    {
        public long Id { get; set; }
        public long CompeticionId { get; set; }
        public string CompeticionNombre { get; set; } = string.Empty;
        public string Etiqueta { get; set; } = string.Empty;
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public string Estado { get; set; } = string.Empty;
    }
}
