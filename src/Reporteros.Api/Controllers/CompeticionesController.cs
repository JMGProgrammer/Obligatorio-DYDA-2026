using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CompeticionesController : ControllerBase
    {
        private readonly ICompeticionService _servicio;

        public CompeticionesController(ICompeticionService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<CompeticionReadDTO>>> ObtenerTodas(CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerTodasAsync(cancellationToken);
            return Ok(resultado);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CompeticionReadDTO>> ObtenerPorId(long id, CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerPorIdAsync(id, cancellationToken);
            if (resultado is null)
                return NotFound();
            return Ok(resultado);
        }

        [Authorize(Roles = "admin,editor")]
        [HttpPost]
        public async Task<ActionResult<CompeticionReadDTO>> Crear([FromBody] CompeticionCreateDTO dto, CancellationToken cancellationToken)
        {
            try
            {
                var creado = await _servicio.CrearAsync(dto, cancellationToken);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = creado.Id }, creado);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}
