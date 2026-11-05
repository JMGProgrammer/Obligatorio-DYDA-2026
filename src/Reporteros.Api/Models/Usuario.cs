namespace Reporteros.Api.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string NombreMostrado { get; set; } = string.Empty;
        public string Rol { get; set; } = "visitante";

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>();
        public ICollection<RevisionResultado> Revisiones { get; set; } = new List<RevisionResultado>();
        public ICollection<RegistroAuditoria> RegistrosAuditoria { get; set; } = new List<RegistroAuditoria>();
    }
}
