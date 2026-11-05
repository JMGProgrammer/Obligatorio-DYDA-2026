namespace Reporteros.Api.DTOs
{
    public class PartidoLecturaDto
    {
        public long Id { get; set; }
        public long TemporadaId { get; set; }
        public string CompeticionNombre { get; set; } = string.Empty;
        public string DeporteNombre { get; set; } = string.Empty;
        public long EquipoLocalId { get; set; }
        public string EquipoLocalNombre { get; set; } = string.Empty;
        public long EquipoVisitanteId { get; set; }
        public string EquipoVisitanteNombre { get; set; } = string.Empty;
        public DateTime ProgramadoEn { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int? PuntosLocal { get; set; }
        public int? PuntosVisitante { get; set; }
        public int? MejorDe { get; set; }
        public long? FuenteId { get; set; }
        public string? FuenteTitulo { get; set; }
        public int Version { get; set; }
        public DateTime? PublicadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
    }
}
