namespace Reporteros.Web.DTOs
{
    public class CompeticionReadDTO
    {
        public long Id { get; set; }
        public long DeporteId { get; set; }
        public string DeporteNombre { get; set; } = string.Empty;
        public long? JuegoId { get; set; }
        public string? JuegoNombre { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ambito { get; set; } = string.Empty;
        public string Formato { get; set; } = string.Empty;
    }
}
