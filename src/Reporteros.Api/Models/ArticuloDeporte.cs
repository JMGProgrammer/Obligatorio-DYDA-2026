namespace Reporteros.Api.Models
{
    public class ArticuloDeporte
    {
        public long ArticuloId { get; set; }
        public long DeporteId { get; set; }

        public Articulo Articulo { get; set; } = null!;
        public Deporte Deporte { get; set; } = null!;
    }
}
