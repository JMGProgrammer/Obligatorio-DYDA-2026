using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IPartidoService
    {
        Task<IReadOnlyList<PartidoReadDTO>> ObtenerPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<PartidoReadDTO>> ObtenerPorFechaAsync(DateTime fecha, long? deporteId, CancellationToken cancellationToken = default);
        Task<PartidoReadDTO> CrearAsync(PartidoCreateDTO dto, CancellationToken cancellationToken = default);
        Task<PartidoReadDTO> PublicarResultadoAsync(long id, long editorUsuarioId, PartidoResultadoDTO dto, CancellationToken cancellationToken = default);
    }
}
