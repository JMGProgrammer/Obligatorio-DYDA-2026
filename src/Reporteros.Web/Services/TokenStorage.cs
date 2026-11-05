namespace Reporteros.Web.Services;

public sealed class TokenStorage
{
    public string? Token { get; private set; }
    public string? Rol { get; private set; }
    public string? Nombre { get; private set; }

    public bool EstaAutenticado => !string.IsNullOrWhiteSpace(Token);

    public event Action? OnChange;

    public void Establecer(string token, string rol, string nombre)
    {
        Token = token;
        Rol = rol;
        Nombre = nombre;
        OnChange?.Invoke();
    }

    public void Limpiar()
    {
        Token = null;
        Rol = null;
        Nombre = null;
        OnChange?.Invoke();
    }
}
