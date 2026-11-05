namespace Reporteros.Api.DTOs
{
    public class PartidoCreateDTO
    {
        public long TemporadaId { get; set; }
        public long EquipoLocalId { get; set; }
        public long EquipoVisitanteId { get; set; }
        public DateTime ProgramadoEn { get; set; }
        public string Estado { get; set; } = "programado";
        public int? MejorDe { get; set; }
        public long? FuenteId { get; set; }
    }
}
