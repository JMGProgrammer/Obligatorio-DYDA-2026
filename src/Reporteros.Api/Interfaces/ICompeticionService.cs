using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface ICompeticionService
    {
        Task<IReadOnlyList<CompeticionReadDTO>> ObtenerTodasAsync(CancellationToken cancellationToken = default);
        Task<CompeticionReadDTO?> ObtenerPorIdAsync(long id, CancellationToken cancellationToken = default);
        Task<CompeticionReadDTO> CrearAsync(CompeticionCreateDTO dto, CancellationToken cancellationToken = default);
    }
}
