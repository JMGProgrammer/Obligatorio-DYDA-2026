namespace Reporteros.Api.DTOs
{
    public class DeporteReadDTO
    {
        public long Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
    }
}
