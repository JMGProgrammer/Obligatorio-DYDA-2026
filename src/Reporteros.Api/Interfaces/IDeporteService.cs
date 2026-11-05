using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IDeporteService
    {
        Task<IReadOnlyList<Deporte>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
    }
}
