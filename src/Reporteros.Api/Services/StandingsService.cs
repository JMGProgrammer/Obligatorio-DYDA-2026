using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class StandingsService : IStandingsService
    {
        private readonly AppDbContext _contexto;

        public StandingsService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<StandingsReadDTO>> ObtenerPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default)
        {
            var temporada = await _contexto.Temporadas
                .Include(t => t.Competicion).ThenInclude(c => c.Deporte)
                .FirstOrDefaultAsync(t => t.Id == temporadaId, cancellationToken);

            if (temporada is null)
                throw new KeyNotFoundException($"Temporada {temporadaId} no existe.");

            int puntosVictoria, puntosEmpate, puntosDerrota;
            var deporteId = temporada.Competicion.DeporteId;
            if (deporteId == 2) // básquetbol
            {
                puntosVictoria = 2; puntosEmpate = 1; puntosDerrota = 0;
            }
            else if (deporteId == 3) // esports
            {
                puntosVictoria = 3; puntosEmpate = 0; puntosDerrota = 0;
            }
            else // fútbol (default)
            {
                puntosVictoria = 3; puntosEmpate = 1; puntosDerrota = 0;
            }

            var equipos = await _contexto.EquiposTemporada
                .Where(et => et.TemporadaId == temporadaId)
                .Select(et => et.Equipo)
                .ToListAsync(cancellationToken);

            var partidos = await _contexto.Partidos
                .Where(p => p.TemporadaId == temporadaId
                            && (p.Estado == "finalizado" || p.Estado == "publicado"))
                .ToListAsync(cancellationToken);

            var stats = equipos.ToDictionary(e => e.Id, e => new StandingsReadDTO
            {
                EquipoId = e.Id,
                EquipoNombre = e.Nombre
            });

            foreach (var p in partidos)
            {
                if (!p.PuntosLocal.HasValue || !p.PuntosVisitante.HasValue)
                    continue;

                if (!stats.TryGetValue(p.EquipoLocalId, out var local) ||
                    !stats.TryGetValue(p.EquipoVisitanteId, out var visitante))
                    continue;

                local.PJ++; visitante.PJ++;
                local.GF += p.PuntosLocal.Value; local.GC += p.PuntosVisitante.Value;
                visitante.GF += p.PuntosVisitante.Value; visitante.GC += p.PuntosLocal.Value;

                if (p.PuntosLocal.Value > p.PuntosVisitante.Value)
                {
                    local.PG++; visitante.PP++;
                    local.Pts += puntosVictoria; visitante.Pts += puntosDerrota;
                }
                else if (p.PuntosLocal.Value < p.PuntosVisitante.Value)
                {
                    visitante.PG++; local.PP++;
                    visitante.Pts += puntosVictoria; local.Pts += puntosDerrota;
                }
                else
                {
                    local.PE++; visitante.PE++;
                    local.Pts += puntosEmpate; visitante.Pts += puntosEmpate;
                }
            }

            foreach (var s in stats.Values)
                s.DG = s.GF - s.GC;

            return stats.Values
                .OrderByDescending(s => s.Pts)
                .ThenByDescending(s => s.DG)
                .ThenByDescending(s => s.GF)
                .ToList();
        }
    }
}
