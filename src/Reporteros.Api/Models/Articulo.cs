namespace Reporteros.Api.Models
{
    public class Articulo
    {
        public long Id { get; set; }
        public long AutorUsuarioId { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Resumen { get; set; } = string.Empty;
        public string Cuerpo { get; set; } = string.Empty;
        public string Estado { get; set; } = "borrador";
        public DateTime? PublicadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; } = DateTime.UtcNow;

        public Usuario Autor { get; set; } = null!;
        public ICollection<ArticuloDeporte> ArticulosDeporte { get; set; } = new List<ArticuloDeporte>();
    }
}
