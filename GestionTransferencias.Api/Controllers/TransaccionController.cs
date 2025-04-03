
using FluentValidation;
using GestionTransferencias.Api.Controllers.GestionTransferencias.Api.Controllers;
using GestionTransferencias.Application.Billeteras.Commands;
using GestionTransferencias.Application.Billeteras.Queries;
using GestionTransferencias.Application.DTOs;
using GestionTransferencias.Application.Movimientos.Commands;
using GestionTransferencias.Application.Transaccion.Commands;
using GestionTransferencias.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GestionTransferencias.Api.Controllers
{
    [Route("api/[controller]")]
    public class TransaccionesController(IMediator mediator, ILogger<TransaccionesController> logger, IValidator<CreateTransaccionCommand> validator) : BaseController(mediator)
    {
        private readonly ILogger<TransaccionesController> _logger = logger;

        // POST: api/Transacciones

        [HttpPost]
        public async Task<ActionResult<TransaccionDto>> PostTransaccion(CreateTransaccionCommand command, CancellationToken cancellationToken)
        {
            // 1. Validación manual con FluentValidation
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
            {
                return BadRequest(new
                {
                    Message = "Error de validación",
                    Errors = validationResult.Errors.Select(e => new
                    {
                        Campo = e.PropertyName,
                        Mensaje = e.ErrorMessage
                    })
                });
            }

            //Obtener BilleteraOrigen con id command.WalletOrigenId, Si no existe lanzar excepción

            var queryOrigen = new GetBilleteraByIdQuery { Id = command.WalletOrigenId };
            //var resultOrigen = await HandleRequest(queryOrigen, cancellationToken);

            var billeteraOrigen = await mediator.Send(queryOrigen, cancellationToken);

            if (billeteraOrigen == null)
            {
                return NotFound($"La billetera origen con id {command.WalletOrigenId} no existe");
            }

            //Obtener BilleteraDestino con id command.WalletDestinoId, Si no existe lanzar excepción 
            var queryDestino = new GetBilleteraByIdQuery { Id = command.WalletDestinoId };

            var billeteraDestino = await mediator.Send(queryDestino, cancellationToken);
            if (billeteraDestino == null)
            {
                return NotFound($"La billetera destino con id {command.WalletDestinoId} no existe");
            }

            //Validar que BilleteraOrigen.Balance>command.Amount, en caso contrario lanzar excepción por monto excede Balance
            if (billeteraOrigen.Balance < command.Amount)
                throw new NotPermitedTransactionException($"El valor de la cantidad de la transacción supera el valor balance disponible en billetera origen: {command.WalletOrigenId}");

            //Ejecutar de forma simultánea:
            //1. Actualizar BilleteraOrigen.Balance=BilleteraOrigen.Balance-command.Amount
            UpdateBilleteraCommand updateBilleteraOrigenCommand = new()
            {
                Balance = billeteraOrigen.Balance - command.Amount,
                DocumentId = billeteraOrigen.DocumentId,
                Name = billeteraOrigen.Name,
                Id = command.WalletOrigenId,
                 UpdatedAt = DateTime.Now,
            };
            await mediator.Send(updateBilleteraOrigenCommand, cancellationToken);
            //2. Actualizar BilleteraDestino.Balance=BilleteraDestino.Balance + command.Amount
            UpdateBilleteraCommand updateBilleteraDestinoCommand = new()
            {
                Balance = billeteraDestino.Balance + command.Amount,
                DocumentId = billeteraDestino.DocumentId,
                Name = billeteraDestino.Name,
                Id = command.WalletDestinoId,
                UpdatedAt = DateTime.Now,
            };
            await mediator.Send(updateBilleteraDestinoCommand, cancellationToken);
            //3. Insertar HistorialMovimiento para Crédito en BilleteraOrigen.Id
            var movimientoOrigenCommand = new CreateMovimientoCommand
            {
                Amount = command.Amount,
                Tipo = "Crédito",
                WalletId = command.WalletOrigenId,
                CreatedAt = DateTime.Now,

            };
            var movimientoOrigenDto = await mediator.Send(movimientoOrigenCommand, cancellationToken);
            //4. Insertar HistorialMovimiento para Débito en BilleteraDestino.Id
            var movimientoDestinoCommand = new CreateMovimientoCommand
            {
                Amount = command.Amount,
                Tipo = "Débito",
                WalletId = command.WalletDestinoId,
                CreatedAt = DateTime.Now,

            };
            var movimientoDestinoDto = await mediator.Send(movimientoDestinoCommand, cancellationToken);

            return new CustomCreatedAtActionResult<TransaccionDto>(
             actionName: nameof(PostTransaccion),
             controllerName: "Transacciones",
             routeValues: new { MovimientoCreditoId = movimientoOrigenDto.Id, MovimientoDebitoId = movimientoDestinoDto.Id },
             value: new TransaccionDto { Amount = command.Amount, WalletDestinoId = movimientoDestinoDto.WalletId, WalletOrigenId = movimientoOrigenDto.WalletId }
            );
        }
    }

    public class CustomCreatedAtActionResult<T>(string actionName,
                                       string controllerName,
                                       object routeValues,
                                       T value) : ActionResult
    {
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var result = new CreatedAtActionResult(
                actionName: actionName,
                controllerName: controllerName,
                routeValues: routeValues,
                value: new
                {
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Resource created successfully",
                    Data = value
                });

            await result.ExecuteResultAsync(context);
        }
    }
}