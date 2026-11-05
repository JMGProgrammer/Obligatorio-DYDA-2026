namespace Reporteros.Api.DTOs
{
    public class LoginRequestDTO
    {
        public string Correo { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
