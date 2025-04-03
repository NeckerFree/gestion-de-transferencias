using GestionTransferencias.Api.Controllers.GestionTransferencias.Api.Controllers;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Movimientos.Commands;
using GestionTransferencias.Application.Movimientos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionTransferencias.Api.Controllers
{
    [Route("api/[controller]")]
    public class MovimientosController(IMediator mediator, ILogger<MovimientosController> logger) : BaseController(mediator)
    {
        private readonly ILogger<MovimientosController> _logger = logger;

        // GET: api/Movimientos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimientoDto>>> GetMovimientos(
            CancellationToken cancellationToken, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {

            _logger.LogInformation($"Fetching all Movimientos");
            var query = new GetMovimientosQuery { PageNumber = pageNumber, PageSize = pageSize };
            return await HandleRequest(query, cancellationToken);
        }

        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovimientoDto>> GetMovimiento( int id, CancellationToken cancellationToken)
        {
            var query = new GetMovimientoByIdQuery { Id = id };
            var Movimiento = await HandleRequest(query, cancellationToken);

            if (Movimiento == null)
            {
                return NotFound();
            }

            return Movimiento;
        }

        // POST: api/Movimientos

        [HttpPost]
        public async Task<ActionResult<MovimientoDto>> PostMovimiento(CreateMovimientoCommand command)
        {
            var Movimiento = await base.Mediator.Send(command);
            return CreatedAtAction(nameof(GetMovimiento), new { id = Movimiento.Id }, Movimiento);
        }
    }
}