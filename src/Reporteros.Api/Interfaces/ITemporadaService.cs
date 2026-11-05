using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface ITemporadaService
    {
        Task<IReadOnlyList<TemporadaLecturaDto>> ObtenerPorCompeticionAsync(long competicionId, CancellationToken cancellationToken = default);
        Task<TemporadaLecturaDto> CrearAsync(TemporadaCreacionDto dto, CancellationToken cancellationToken = default);
    }
}
