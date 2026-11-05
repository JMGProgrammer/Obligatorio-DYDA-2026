using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TemporadasController : ControllerBase
    {
        private readonly ITemporadaService _servicio;

        public TemporadasController(ITemporadaService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet("por-competicion/{competicionId:long}")]
        public async Task<ActionResult<IReadOnlyList<TemporadaReadDTO>>> ObtenerPorCompeticion(long competicionId, CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPorCompeticionAsync(competicionId, cancellationToken);
            return Ok(resultado);
        }

        [Authorize(Roles = "admin,editor")]
        [HttpPost]
        public async Task<ActionResult<TemporadaReadDTO>> Crear([FromBody] TemporadaCreateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var creado = await _servicio.CrearAsync(dto, cancellationToken);
                return CreatedAtAction(nameof(ObtenerPorCompeticion), new { competicionId = creado.CompeticionId }, creado);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
