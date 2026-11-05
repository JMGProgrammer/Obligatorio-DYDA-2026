namespace Reporteros.Api.Models
{
    public class Competicion
    {
        public long Id { get; set; }
        public long DeporteId { get; set; }
        public long? JuegoId { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Ambito { get; set; } = string.Empty;
        public string Formato { get; set; } = string.Empty;

        public Deporte Deporte { get; set; } = null!;
        public Juego? Juego { get; set; }
        public ICollection<Temporada> Temporadas { get; set; } = new List<Temporada>();
    }
}
