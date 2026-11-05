using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class CompeticionService : ICompeticionService
    {
        private readonly AppDbContext _contexto;

        public CompeticionService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IReadOnlyList<CompeticionLecturaDto>> ObtenerTodasAsync(CancellationToken cancellationToken = default)
        {
            return await _contexto.Competiciones
                .AsNoTracking()
                .Include(c => c.Deporte)
                .Include(c => c.Juego)
                .OrderBy(c => c.Nombre)
                .Select(c => new CompeticionLecturaDto
                {
                    Id = c.Id,
                    DeporteId = c.DeporteId,
                    DeporteNombre = c.Deporte.Nombre,
                    JuegoId = c.JuegoId,
                    JuegoNombre = c.Juego != null ? c.Juego.Nombre : null,
                    Nombre = c.Nombre,
                    Ambito = c.Ambito,
                    Formato = c.Formato
                })
                .ToListAsync(cancellationToken);
        }

        public async Task<CompeticionLecturaDto?> ObtenerPorIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _contexto.Competiciones
                .AsNoTracking()
                .Include(c => c.Deporte)
                .Include(c => c.Juego)
                .Where(c => c.Id == id)
                .Select(c => new CompeticionLecturaDto
                {
                    Id = c.Id,
                    DeporteId = c.DeporteId,
                    DeporteNombre = c.Deporte.Nombre,
                    JuegoId = c.JuegoId,
                    JuegoNombre = c.Juego != null ? c.Juego.Nombre : null,
                    Nombre = c.Nombre,
                    Ambito = c.Ambito,
                    Formato = c.Formato
                })
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<CompeticionLecturaDto> CrearAsync(CompeticionCreacionDto dto, CancellationToken cancellationToken = default)
        {
            var deporte = await _contexto.Deportes.FindAsync(new object[] { dto.DeporteId }, cancellationToken);
            if (deporte is null)
                throw new KeyNotFoundException($"Deporte {dto.DeporteId} no existe.");

            if (dto.JuegoId.HasValue)
            {
                var juego = await _contexto.Juegos.FindAsync(new object[] { dto.JuegoId.Value }, cancellationToken);
                if (juego is null)
                    throw new KeyNotFoundException($"Juego {dto.JuegoId.Value} no existe.");
            }

            var competicion = new Competicion
            {
                DeporteId = dto.DeporteId,
                JuegoId = dto.JuegoId,
                Nombre = dto.Nombre,
                Ambito = dto.Ambito,
                Formato = dto.Formato
            };

            _contexto.Competiciones.Add(competicion);
            await _contexto.SaveChangesAsync(cancellationToken);

            return (await ObtenerPorIdAsync(competicion.Id, cancellationToken))!;
        }
    }
}
