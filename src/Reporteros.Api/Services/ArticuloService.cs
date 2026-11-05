using Microsoft.EntityFrameworkCore;
using Reporteros.Api.Data;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Services
{
    public class ArticuloService : IArticuloService
    {
        private readonly AppDbContext _contexto;

        public ArticuloService(AppDbContext contexto)
        {
            _contexto = contexto;
        }

        private static ArticuloReadDTO Mapear(Articulo a) => new ArticuloReadDTO
        {
            Id = a.Id,
            AutorUsuarioId = a.AutorUsuarioId,
            AutorNombre = a.Autor.NombreMostrado,
            Slug = a.Slug,
            Titulo = a.Titulo,
            Resumen = a.Resumen,
            Cuerpo = a.Cuerpo,
            Estado = a.Estado,
            PublicadoEn = a.PublicadoEn,
            ActualizadoEn = a.ActualizadoEn
        };

        public async Task<IReadOnlyList<ArticuloReadDTO>> ObtenerPublicadosAsync(CancellationToken cancellationToken = default)
        {
            var articulos = await _contexto.Articulos
                .AsNoTracking()
                .Include(a => a.Autor)
                .Where(a => a.Estado == "publicado")
                .OrderByDescending(a => a.PublicadoEn)
                .ToListAsync(cancellationToken);

            return articulos.Select(Mapear).ToList();
        }

        public async Task<ArticuloReadDTO?> ObtenerPorSlugAsync(string slug, CancellationToken cancellationToken = default)
        {
            var articulo = await _contexto.Articulos
                .AsNoTracking()
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(a => a.Slug == slug, cancellationToken);

            if (articulo is null)
                return null;

            // Borradores no son visibles publicamente
            if (articulo.Estado != "publicado")
                return null;

            return Mapear(articulo);
        }

        public async Task<ArticuloReadDTO> CrearBorradorAsync(ArticuloCreateDTO dto, CancellationToken cancellationToken = default)
        {
            var autor = await _contexto.Usuarios.FindAsync(new object[] { dto.AutorUsuarioId }, cancellationToken);
            if (autor is null)
                throw new KeyNotFoundException($"Usuario {dto.AutorUsuarioId} no existe.");

            if (await _contexto.Articulos.AnyAsync(a => a.Slug == dto.Slug, cancellationToken))
                throw new InvalidOperationException($"Ya existe un articulo con slug '{dto.Slug}'.");

            var articulo = new Articulo
            {
                AutorUsuarioId = dto.AutorUsuarioId,
                Slug = dto.Slug,
                Titulo = dto.Titulo,
                Resumen = dto.Resumen,
                Cuerpo = dto.Cuerpo,
                Estado = "borrador"
            };

            _contexto.Articulos.Add(articulo);
            await _contexto.SaveChangesAsync(cancellationToken);

            var creado = await _contexto.Articulos
                .Include(a => a.Autor)
                .FirstAsync(a => a.Id == articulo.Id, cancellationToken);

            return Mapear(creado);
        }

        public async Task<ArticuloReadDTO> PublicarAsync(long id, CancellationToken cancellationToken = default)
        {
            var articulo = await _contexto.Articulos
                .Include(a => a.Autor)
                .FirstOrDefaultAsync(a => a.Id == id, cancellationToken);

            if (articulo is null)
                throw new KeyNotFoundException($"Articulo {id} no existe.");

            if (articulo.Estado == "publicado")
                return Mapear(articulo);

            articulo.Estado = "publicado";
            articulo.PublicadoEn = DateTime.UtcNow;
            articulo.ActualizadoEn = DateTime.UtcNow;

            await _contexto.SaveChangesAsync(cancellationToken);
            return Mapear(articulo);
        }
    }
}
