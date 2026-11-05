namespace Reporteros.Api.DTOs
{
    public class StandingsReadDTO
    {
        public long EquipoId { get; set; }
        public string EquipoNombre { get; set; } = string.Empty;
        public int PJ { get; set; }  // partidos jugados
        public int PG { get; set; }  // ganados
        public int PE { get; set; }  // empatados
        public int PP { get; set; }  // perdidos
        public int GF { get; set; }  // goles/puntos a favor
        public int GC { get; set; }  // goles/puntos en contra
        public int DG { get; set; }  // diferencia
        public int Pts { get; set; } // puntos
    }
}
