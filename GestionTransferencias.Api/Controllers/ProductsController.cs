using GestionTransferencias.Api.Controllers.GestionTransferencias.Api.Controllers;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.Billeteras.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionTransferencias.Api.Controllers
{
    [Route("api/[controller]")]
    public class BilleterasController(IMediator mediator, ILogger<BilleterasController> logger) : BaseController(mediator)
    {
        private readonly ILogger<BilleterasController> _logger = logger;

        // GET: api/Billeteras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BilleteraDto>>> GetBilleteras(
            CancellationToken cancellationToken, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {

            _logger.LogInformation($"Fetching all Billeteras");
            var query = new GetBilleterasQuery { PageNumber = pageNumber, PageSize = pageSize };
            return await HandleRequest(query, cancellationToken);
        }

        // GET: api/Billeteras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BilleteraDto>> GetBilletera( int id, CancellationToken cancellationToken)
        {
            var query = new GetBilleteraByIdQuery { Id = id };
            var Billetera = await HandleRequest(query, cancellationToken);

            if (Billetera == null)
            {
                return NotFound();
            }

            return Billetera;
        }

        // POST: api/Billeteras
        
        [HttpPost]
        public async Task<ActionResult<BilleteraDto>> PostBilletera(CreateBilleteraCommand command)
        {
            var Billetera = await base.Mediator.Send(command); // Billetera is of type BilleteraDto
            return CreatedAtAction(nameof(GetBilletera), new { id = Billetera.Id }, Billetera);
        }
        // PUT: api/Billeteras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilletera(int id, UpdateBilleteraCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            return await HandleNoContentRequest(command);
        }

        // DELETE: api/Billeteras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilletera(int id)
        {
            var command = new DeleteBilleteraCommand { Id = id };
            return await HandleNoContentRequest(command);
        }
    }
}