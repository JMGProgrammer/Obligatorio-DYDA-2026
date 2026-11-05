namespace Reporteros.Api.DTOs
{
    public class UsuarioInfoDTO
    {
        public long Id { get; set; }
        public string Correo { get; set; } = string.Empty;
        public string NombreMostrado { get; set; } = string.Empty;
        public string Rol { get; set; } = string.Empty;
    }
}
