using Microsoft.AspNetCore.Mvc;
using Reporteros.Api.DTOs;
using Reporteros.Api.Interfaces;
using Reporteros.Api.Models;

namespace Reporteros.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DeportesController : ControllerBase
    {
        private readonly IDeporteService _servicio;

        public DeportesController(IDeporteService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<DeporteLecturaDto>>> ObtenerTodos(CancellationToken cancellationToken)
        {
            var deportes = await _servicio.ObtenerTodosAsync(cancellationToken);

            var dto = deportes.Select(d => new DeporteLecturaDto
            {
                Id = d.Id,
                Slug = d.Slug,
                Nombre = d.Nombre,
                Tipo = d.Tipo
            }).ToList();

            return Ok(dto);
        }
    }
}
