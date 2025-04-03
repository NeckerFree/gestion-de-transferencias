namespace GestionTransferencias.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    namespace GestionTransferencias.Api.Controllers
    {
        [ApiController]
        [Route("api/[controller]")]
        public abstract class BaseController(IMediator mediator) : ControllerBase
        {
            protected readonly IMediator Mediator = mediator;

            /// <summary>
            /// Handles sending a MediatR request and returning an appropriate response.
            /// </summary>
            /// <typeparam name="TResponse">The type of the response.</typeparam>
            /// <param name="request">The MediatR request.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>An ActionResult containing the response.</returns>
            protected async Task<ActionResult<TResponse>> HandleRequest<TResponse>(
                IRequest<TResponse> request, CancellationToken cancellationToken = default)
            {
                var response = await Mediator.Send(request, cancellationToken);
                return Ok(response);
            }

            /// <summary>
            /// Handles sending a MediatR request and returning a CreatedAtAction response.
            /// </summary>
            /// <typeparam name="TResponse">The type of the response.</typeparam>
            /// <param name="request">The MediatR request.</param>
            /// <param name="actionName">The name of the action to use for generating the URL.</param>
            /// <param name="routeValues">The route values to include in the URL.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A CreatedAtActionResult containing the response.</returns>
            protected async Task<ActionResult<TResponse>> HandleCreateRequest<TResponse>(
                IRequest<TResponse> request, string actionName, object routeValues, CancellationToken cancellationToken = default)
            {
                var response = await Mediator.Send(request, cancellationToken);
                return CreatedAtAction(actionName, routeValues, response);
            }

            /// <summary>
            /// Handles sending a MediatR request and returning a NoContent response.
            /// </summary>
            /// <param name="request">The MediatR request.</param>
            /// <param name="cancellationToken">The cancellation token.</param>
            /// <returns>A NoContentResult.</returns>
            protected async Task<IActionResult> HandleNoContentRequest(
                IRequest<bool> request, CancellationToken cancellationToken = default)
            {
                var result = await Mediator.Send(request, cancellationToken);
                return result ? NoContent() : NotFound();
            }
        }
    }
}
