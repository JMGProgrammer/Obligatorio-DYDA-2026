using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class PartidoService : IPartidoService
    {
        private readonly AppDbContext _contexto;

        public PartidoService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        private static PartidoReadDTO Mapear(Partido p) => new PartidoReadDTO
        {
            Id = p.Id,
            TemporadaId = p.TemporadaId,
            CompeticionNombre = p.Temporada.Competicion.Nombre,
            DeporteNombre = p.Temporada.Competicion.Deporte.Nombre,
            EquipoLocalId = p.EquipoLocalId,
            EquipoLocalNombre = p.EquipoLocal.Nombre,
            EquipoVisitanteId = p.EquipoVisitanteId,
            EquipoVisitanteNombre = p.EquipoVisitante.Nombre,
            ProgramadoEn = p.ProgramadoEn,
            Estado = p.Estado,
            PuntosLocal = p.PuntosLocal,
            PuntosVisitante = p.PuntosVisitante,
            MejorDe = p.MejorDe,
            FuenteId = p.FuenteId,
            FuenteTitulo = p.Fuente?.Titulo,
            Version = p.Version,
            PublicadoEn = p.PublicadoEn,
            ActualizadoEn = p.ActualizadoEn
        };

        private IQueryable<Partido> ConsultaBase() =>
            _contexto.Partidos
                .AsNoTracking()
                .Include(p => p.Temporada).ThenInclude(t => t.Competicion).ThenInclude(c => c.Deporte)
                .Include(p => p.EquipoLocal)
                .Include(p => p.EquipoVisitante)
                .Include(p => p.Fuente);

        public async Task<IReadOnlyList<PartidoReadDTO>> ObtenerPorTemporadaAsync(long temporadaId, CancellationToken cancellationToken = default)
        {
            var partidos = await ConsultaBase()
                .Where(p => p.TemporadaId == temporadaId)
                .OrderBy(p => p.ProgramadoEn)
                .ToListAsync(cancellationToken);

            return partidos.Select(Mapear).ToList();
        }

        public async Task<IReadOnlyList<PartidoReadDTO>> ObtenerPorFechaAsync(DateTime fecha, long? deporteId, CancellationToken cancellationToken = default)
        {
            var inicio = fecha.Date;
            var fin = inicio.AddDays(1);

            var query = ConsultaBase().Where(p => p.ProgramadoEn >= inicio && p.ProgramadoEn < fin);

            if (deporteId.HasValue)
                query = query.Where(p => p.Temporada.Competicion.DeporteId == deporteId.Value);

            var partidos = await query.OrderBy(p => p.ProgramadoEn).ToListAsync(cancellationToken);
            return partidos.Select(Mapear).ToList();
        }

        public async Task<PartidoReadDTO> CrearAsync(PartidoCreateDTO dto, CancellationToken cancellationToken = default)
        {
            if (dto.EquipoLocalId == dto.EquipoVisitanteId)
                throw new ArgumentException("El equipo local y el visitante no pueden ser el mismo.");

            var temporada = await _contexto.Temporadas.FindAsync(new object[] { dto.TemporadaId }, cancellationToken);
            if (temporada is null)
                throw new KeyNotFoundException($"Temporada {dto.TemporadaId} no existe.");

            var local = await _contexto.Equipos.FindAsync(new object[] { dto.EquipoLocalId }, cancellationToken);
            var visitante = await _contexto.Equipos.FindAsync(new object[] { dto.EquipoVisitanteId }, cancellationToken);
            if (local is null || visitante is null)
                throw new KeyNotFoundException("Equipo local o visitante no existe.");

            if (dto.FuenteId.HasValue)
            {
                var fuente = await _contexto.Fuentes.FindAsync(new object[] { dto.FuenteId.Value }, cancellationToken);
                if (fuente is null)
                    throw new KeyNotFoundException($"Fuente {dto.FuenteId.Value} no existe.");
            }

            var partido = new Partido
            {
                TemporadaId = dto.TemporadaId,
                EquipoLocalId = dto.EquipoLocalId,
                EquipoVisitanteId = dto.EquipoVisitanteId,
                ProgramadoEn = dto.ProgramadoEn,
                Estado = dto.Estado,
                MejorDe = dto.MejorDe,
                FuenteId = dto.FuenteId
            };

            _contexto.Partidos.Add(partido);
            await _contexto.SaveChangesAsync(cancellationToken);

            // Recargar con includes para el DTO
            var creado = await ConsultaBase().FirstAsync(p => p.Id == partido.Id, cancellationToken);
            return Mapear(creado);
        }

        public async Task<PartidoReadDTO> PublicarResultadoAsync(long id, long editorUsuarioId, PartidoResultadoDTO dto, CancellationToken cancellationToken = default)
        {
            using var transaccion = await _contexto.Database.BeginTransactionAsync(cancellationToken);

            var partido = await _contexto.Partidos
                .Include(p => p.Temporada).ThenInclude(t => t.Competicion).ThenInclude(c => c.Deporte)
                .Include(p => p.EquipoLocal)
                .Include(p => p.EquipoVisitante)
                .Include(p => p.Fuente)
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            if (partido is null)
                throw new KeyNotFoundException($"Partido {id} no existe.");

            if (partido.Version != dto.Version)
                throw new InvalidOperationException($"Conflicto de version: el partido esta en version {partido.Version}, se envio {dto.Version} (409).");

            var anterior = System.Text.Json.JsonSerializer.Serialize(new
            {
                partido.PuntosLocal,
                partido.PuntosVisitante,
                partido.Estado,
                partido.Version
            });

            partido.PuntosLocal = dto.PuntosLocal;
            partido.PuntosVisitante = dto.PuntosVisitante;
            partido.Estado = dto.Estado;
            partido.Version += 1;
            partido.ActualizadoEn = DateTime.UtcNow;
            if (dto.Estado == "finalizado" || dto.Estado == "publicado")
                partido.PublicadoEn ??= DateTime.UtcNow;

            var revision = new RevisionResultado
            {
                PartidoId = partido.Id,
                EditorUsuarioId = editorUsuarioId,
                AnteriorJson = anterior,
                NuevoJson = System.Text.Json.JsonSerializer.Serialize(new
                {
                    partido.PuntosLocal,
                    partido.PuntosVisitante,
                    partido.Estado,
                    partido.Version
                }),
                Motivo = dto.Motivo,
                CambiadoEn = DateTime.UtcNow
            };
            _contexto.RevisionesResultado.Add(revision);

            var auditoria = new RegistroAuditoria
            {
                ActorUsuarioId = editorUsuarioId,
                Accion = "publicar_resultado",
                TipoEntidad = "Partido",
                EntidadId = partido.Id,
                OcurridoEn = DateTime.UtcNow,
                DetallesJson = System.Text.Json.JsonSerializer.Serialize(new
                {
                    partido.PuntosLocal,
                    partido.PuntosVisitante,
                    partido.Estado,
                    Motivo = dto.Motivo
                })
            };
            _contexto.RegistrosAuditoria.Add(auditoria);

            await _contexto.SaveChangesAsync(cancellationToken);
            await transaccion.CommitAsync(cancellationToken);

            return Mapear(partido);
        }
    }
}
