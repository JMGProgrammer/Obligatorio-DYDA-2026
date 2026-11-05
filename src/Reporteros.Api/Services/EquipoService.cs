using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class EquipoService : IEquipoService
    {
        private readonly AppDbContext _contexto;

        public EquipoService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<EquipoReadDTO>> ObtenerTodosAsync(CancellationToken cancellationToken = default)
        {
            return await _contexto.Equipos
                .AsNoTracking()
                .OrderBy(e => e.Nombre)
                .Select(e => new EquipoReadDTO
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    Slug = e.Slug,
                    Region = e.Region,
                    UrlLogo = e.UrlLogo
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<EquipoReadDTO> CrearAsync(EquipoCreateDTO dto, CancellationToken cancellationToken = default)
        {
            var equipo = new Equipo
            {
                Nombre = dto.Nombre,
                Slug = dto.Slug,
                Region = dto.Region,
                UrlLogo = dto.UrlLogo
            };

            _contexto.Equipos.Add(equipo);
            await _contexto.SaveChangesAsync(cancellationToken);

            return new EquipoReadDTO
            {
                Id = equipo.Id,
                Nombre = equipo.Nombre,
                Slug = equipo.Slug,
                Region = equipo.Region,
                UrlLogo = equipo.UrlLogo
            };
        }
    }
}
