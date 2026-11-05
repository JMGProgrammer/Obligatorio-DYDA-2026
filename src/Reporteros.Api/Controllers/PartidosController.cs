using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PartidosController : ControllerBase
    {
        private readonly IPartidoService _servicio;

        public PartidosController(IPartidoService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("por-temporada/{temporadaId:long}")]
        public async Task<ActionResult<IReadOnlyList<PartidoLecturaDto>>> ObtenerPorTemporada(long temporadaId, CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPorTemporadaAsync(temporadaId, cancellationToken);
            return Ok(resultado);
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<PartidoLecturaDto>>> ObtenerPorFecha([FromQuery] DateTime fecha, [FromQuery] long? deporteId, CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPorFechaAsync(fecha, deporteId, cancellationToken);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<PartidoLecturaDto>> Crear([FromBody] PartidoCreacionDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var creado = await _servicio.CrearAsync(dto, cancellationToken);
                return CreatedAtAction(nameof(ObtenerPorTemporada), new { temporadaId = creado.TemporadaId }, creado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPut("{id:long}/resultado")]
        public async Task<ActionResult<PartidoLecturaDto>> PublicarResultado(long id, [FromQuery] long editorId, [FromBody] PartidoResultadoDto dto, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _servicio.PublicarResultadoAsync(id, editorId, dto, cancellationToken);
                return Ok(resultado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { error = ex.Message });
            }
        }
    }
}
