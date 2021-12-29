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

        [HttpGet("{Id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(PuertaGetByIdQueryResult))]
        public async Task<IActionResult> GetById(string Id, CancellationToken cancellationToken)
        {
           var response = await _mediator.Send(new PuertaGetByIdQuery(Id), cancellationToken);

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

        [HttpGet("Activo/{activo?}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PuertaGetListByActivoQueryResult>))]
        public async Task<IActionResult> GetListByActivo( CancellationToken cancellationToken, bool? activo = null)
        {
            var response = await _mediator.Send(new PuertaGetListByActivoQuery { Activo=activo}, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

    }
}
