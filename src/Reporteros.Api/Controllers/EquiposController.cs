using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class EquiposController : ControllerBase
    {
        private readonly IEquipoService _servicio;

        public EquiposController(IEquipoService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EquipoReadDTO>>> ObtenerTodos(CancellationToken cancellationToken)
        {
            var resultado = await _servicio.ObtenerTodosAsync(cancellationToken);
            return Ok(resultado);
        }

        [HttpPost]
        public async Task<ActionResult<EquipoReadDTO>> Crear([FromBody] EquipoCreateDTO dto, CancellationToken cancellationToken)
        {
            var creado = await _servicio.CrearAsync(dto, cancellationToken);
            return CreatedAtAction(nameof(ObtenerTodos), creado);
        }
    }
}
