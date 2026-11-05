using Reporteros.Api.DTOs;
using Reporteros.Api.Models;

namespace Reporteros.Api.Interfaces
{
    public interface IArticuloService
    {
        Task<IReadOnlyList<ArticuloReadDTO>> ObtenerPublicadosAsync(CancellationToken cancellationToken = default);
        Task<ArticuloReadDTO?> ObtenerPorSlugAsync(string slug, CancellationToken cancellationToken = default);
        Task<ArticuloReadDTO> CrearBorradorAsync(ArticuloCreateDTO dto, CancellationToken cancellationToken = default);
        Task<ArticuloReadDTO> PublicarAsync(long id, CancellationToken cancellationToken = default);
    }
}
