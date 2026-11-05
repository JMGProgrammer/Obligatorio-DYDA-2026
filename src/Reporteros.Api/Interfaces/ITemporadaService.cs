using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface ITemporadaService
    {
        Task<IReadOnlyList<TemporadaReadDTO>> ObtenerPorCompeticionAsync(long competicionId, CancellationToken cancellationToken = default);
        Task<TemporadaReadDTO> CrearAsync(TemporadaCreateDTO dto, CancellationToken cancellationToken = default);
    }
}
