using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IPartidoService
    {
        Task<IReadOnlyList<PartidoLecturaDto>> ObtenerPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<PartidoLecturaDto>> ObtenerPorFechaAsync(DateTime fecha, long? deporteId, CancellationToken cancellationToken = default);
        Task<PartidoLecturaDto> CrearAsync(PartidoCreacionDto dto, CancellationToken cancellationToken = default);
        Task<PartidoLecturaDto> PublicarResultadoAsync(long id, long editorUsuarioId, PartidoResultadoDto dto, CancellationToken cancellationToken = default);
    }
}
