namespace Reporteros.Api.Models
{
    public class Fuente
    {
        public long Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string? Url { get; set; }
        public DateTime? CapturadoEn { get; set; }
        public string? Confianza { get; set; }
        public string? Atribucion { get; set; }

        public ICollection<Partido> Partidos { get; set; } = new List<Partido>();
    }
}
