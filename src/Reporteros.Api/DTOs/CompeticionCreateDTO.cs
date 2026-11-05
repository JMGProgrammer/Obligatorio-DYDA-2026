namespace Reporteros.Api.DTOs
{
    public class CompeticionCreateDTO
    {
        public long DeporteId { get; set; }
        public long? JuegoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ambito { get; set; } = string.Empty;
        public string Formato { get; set; } = string.Empty;
    }
}
