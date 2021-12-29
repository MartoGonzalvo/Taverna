using ControlPortales.Application.Commands.PuertaCommands;
using ControlPortales.Application.Queries.PuertaQueries;
using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlPortales.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class PuertaController : ControllerBase
    {
        private readonly ILogger<PuertaController> _logger;
        private readonly IMediator _mediator;
        public PuertaController(ILogger<PuertaController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PuertaGetByIdQueryResult))]
        public async Task<IActionResult> GetById([FromQuery] PuertaGetByIdQuery query, CancellationToken cancellationToken)
        {
           var response = await _mediator.Send(query, cancellationToken);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post(PuertaCreateCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PuertaGetListByActivoQueryResult>))]
        public async Task<IActionResult> GetListByActivo([FromQuery] PuertaGetListByActivoQuery query, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(query, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

    }
}
