using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class TemporadaService : ITemporadaService
    {
        private readonly AppDbContext _contexto;

        public TemporadaService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<TemporadaLecturaDto>> ObtenerPorCompeticionAsync(long competicionId, CancellationToken cancellationToken = default)
        {
            return await _contexto.Temporadas
                .AsNoTracking()
                .Include(t => t.Competicion)
                .Where(t => t.CompeticionId == competicionId)
                .OrderBy(t => t.Inicio)
                .Select(t => new TemporadaLecturaDto
                {
                    Id = t.Id,
                    CompeticionId = t.CompeticionId,
                    CompeticionNombre = t.Competicion.Nombre,
                    Etiqueta = t.Etiqueta,
                    Inicio = t.Inicio,
                    Fin = t.Fin,
                    Estado = t.Estado
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<TemporadaLecturaDto> CrearAsync(TemporadaCreacionDto dto, CancellationToken cancellationToken = default)
        {
            var competicion = await _contexto.Competiciones.FindAsync(new object[] { dto.CompeticionId }, cancellationToken);
            if (competicion is null)
                throw new KeyNotFoundException($"Competicion {dto.CompeticionId} no existe.");

            var temporada = new Temporada
            {
                CompeticionId = dto.CompeticionId,
                Etiqueta = dto.Etiqueta,
                Inicio = dto.Inicio,
                Fin = dto.Fin,
                Estado = dto.Estado,
                ReglasJson = dto.ReglasJson
            };

            _contexto.Temporadas.Add(temporada);
            await _contexto.SaveChangesAsync(cancellationToken);

            return new TemporadaLecturaDto
            {
                Id = temporada.Id,
                CompeticionId = temporada.CompeticionId,
                CompeticionNombre = competicion.Nombre,
                Etiqueta = temporada.Etiqueta,
                Inicio = temporada.Inicio,
                Fin = temporada.Fin,
                Estado = temporada.Estado
            };
        }
    }
}
