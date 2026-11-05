namespace Reporteros.Web.Services;

public sealed class TokenStorage
{
    public string? Token { get; set; }
    public string? Rol { get; set; }
    public string? Nombre { get; set; }

    public bool EstaAutenticado => !string.IsNullOrWhiteSpace(Token);

    public void Limpiar()
    {
        Token = null;
        Rol = null;
        Nombre = null;
    }
}
