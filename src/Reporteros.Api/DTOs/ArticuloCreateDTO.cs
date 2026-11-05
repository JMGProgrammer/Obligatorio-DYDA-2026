namespace Reporteros.Api.DTOs
{
    public class ArticuloCreateDTO
    {
        public long AutorUsuarioId { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
    }
}
