using ControlPortales.Application.Commands.PuertaComands;
using ControlPortales.Application.Commands.PuertaCommands;
using ControlPortales.Application.Queries.PuertaQueries;
using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ControlPortales.Api.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
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
        [ProducesResponseType(200, Type = typeof(IEnumerable<PuertaGetListByActivoQueryResult>))]
        public async Task<IActionResult> GetListByActivo( CancellationToken cancellationToken, bool? activo = null)
        {
            var response = await _mediator.Send(new PuertaGetListByActivoQuery { Activo=activo}, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

        [HttpGet("Cliente/{idCliente}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PuertaGetListByClienteQueryResult>))]
        public async Task<IActionResult> GetListByCliente(CancellationToken cancellationToken, int idCliente)
        {
            var response = await _mediator.Send(new PuertaGetListByClienteQuery { idCliente = idCliente }, cancellationToken);

            if (!response.Any())
                return NotFound();

            return Ok(response);
        }

        [HttpPost("Update")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Post(PuertaUpdateCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("UpdateEstado")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateEstado(PuertaUpdateEstadoCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

        [HttpPost("UpdateActivo")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> UpdateActivo(PuertaUpdateActivoCommand command, CancellationToken cancellationToken)
        {
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }

    }
}
