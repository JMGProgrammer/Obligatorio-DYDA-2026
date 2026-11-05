using Reporteros.Api.DTOs;

namespace Reporteros.Api.Interfaces
{
    public interface IStandingsService
    {
        Task<IReadOnlyList<StandingsReadDTO>> ObtenerPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default);
    }
}
