using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private readonly IArticuloService _servicio;

        public ArticulosController(IArticuloService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ArticuloReadDTO>>> ObtenerPublicados(CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPublicadosAsync(cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<ArticuloReadDTO>> ObtenerPorSlug(string slug, CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPorSlugAsync(slug, cancellationToken);
            if (resultado is null)
                return NotFound();
            return Ok(resultado);
        }

        [Authorize(Roles = "admin,editor")]
        [HttpPost]
        [Route("/api/v1/admin/articulos")]
        public async Task<ActionResult<ArticuloReadDTO>> CrearBorrador([FromBody] ArticuloCreateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var creado = await _servicio.CrearBorradorAsync(dto, cancellationToken);
                return CreatedAtAction(nameof(ObtenerPorSlug), new { slug = creado.Slug }, creado);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
        }

        [Authorize(Roles = "admin,editor,revisor")]
        [HttpPost("{id:long}/publish")]
        [Route("/api/v1/admin/articulos/{id:long}/publish")]
        public async Task<ActionResult<ArticuloReadDTO>> Publicar(long id, CancellationToken cancellationToken)
        {
            try
            {
                var publicado = await _servicio.PublicarAsync(id, cancellationToken);
                return Ok(publicado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
