namespace Reporteros.Api.DTOs
{
    public class ArticuloReadDTO
    {
        public long Id { get; set; }
        public long AutorUsuarioId { get; set; }
        public string AutorNombre { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime? PublicadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
    }
}
