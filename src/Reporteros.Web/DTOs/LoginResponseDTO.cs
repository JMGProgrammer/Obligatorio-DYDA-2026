namespace Reporteros.Web.DTOs
{
    public class LoginResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public DateTime ExpiraEn { get; set; }
        public UsuarioInfoDTO Usuario { get; set; } = new();
    }
}
