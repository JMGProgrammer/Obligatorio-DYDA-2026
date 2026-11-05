using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/temporadas/{temporadaId:long}/clasificacion")]
    public class StandingsController : ControllerBase
    {
        private readonly IStandingsService _servicio;

        public StandingsController(IStandingsService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<StandingsReadDTO>>> Obtener(long temporadaId, CancellationToken cancellationToken)
        {
            try
            {
                var resultado = await _servicio.ObtenerPorTemporadaAsync(temporadaId, cancellationToken);
                return Ok(resultado);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }
    }
}
