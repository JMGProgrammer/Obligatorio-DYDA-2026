namespace Reporteros.Api.Models
{
    public class Deporte
    {
        public long Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Tipo { get; set; } = "tradicional"; // tradicional | esports

        public ICollection<Juego> Juegos { get; set; } = new List<Juego>();
        public ICollection<Competicion> Competiciones { get; set; } = new List<Competicion>();
        public ICollection<ArticuloDeporte> ArticulosDeporte { get; set; } = new List<ArticuloDeporte>();
    }
}
