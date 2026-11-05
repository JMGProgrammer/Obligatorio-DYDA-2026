using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IEquipoService
    {
        Task<IReadOnlyList<EquipoLecturaDto>> ObtenerTodosAsync(CancellationToken cancellationToken = default);
        Task<EquipoLecturaDto> CrearAsync(EquipoCreacionDto dto, CancellationToken cancellationToken = default);
    }
}
