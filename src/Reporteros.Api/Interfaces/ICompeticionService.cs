using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface ICompeticionService
    {
        Task<IReadOnlyList<CompeticionLecturaDto>> ObtenerTodasAsync(CancellationToken cancellationToken = default);
        Task<CompeticionLecturaDto?> ObtenerPorIdAsync(long id, CancellationToken cancellationToken = default);
        Task<CompeticionLecturaDto> CrearAsync(CompeticionCreacionDto dto, CancellationToken cancellationToken = default);
    }
}
