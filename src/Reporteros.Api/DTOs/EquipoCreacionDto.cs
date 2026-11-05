namespace Reporteros.Api.DTOs
{
    public class EquipoCreacionDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string? Region { get; set; }
        public string? UrlLogo { get; set; }
    }
}
