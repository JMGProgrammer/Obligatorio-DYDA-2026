using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class DeporteService : IDeporteService
    {
        private readonly AppDbContext _contexto;

        public DeporteService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<Deporte>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _contexto.Deportes
                .AsNoTracking()
                .OrderBy(d => d.Nombre)
                .ToListAsync(cancellationToken);
        }
    }
}
