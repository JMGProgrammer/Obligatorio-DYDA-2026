namespace Reporteros.Api.Models
{
    public class Juego
    {
        public long Id { get; set; }
        public string Slug { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;

        public long DeporteId { get; set; }
        public Deporte Deporte { get; set; } = null!;

        public ICollection<Competicion> Competiciones { get; set; } = new List<Competicion>();
    }
}
