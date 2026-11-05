using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IEquipoService
    {
        Task<IReadOnlyList<EquipoReadDTO>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
        Task<EquipoReadDTO> CrearAsync(EquipoCreateDTO dto, CancellationToken cancellationToken = default);
    }
}
