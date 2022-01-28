using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaComands
{
    public class PuertaUpdateActivoCommandHandler : IRequestHandler<PuertaUpdateActivoCommand, bool>
    {
        private readonly CosmosDbContext _cosmosDbContext;
        private IMediator _mediator;
        private ILogger<PuertaUpdateActivoCommand> _logger;

        public PuertaUpdateActivoCommandHandler(CosmosDbContext cosmosDbContext, IMediator mediator, ILogger<PuertaUpdateActivoCommand> logger)
        {
            _cosmosDbContext = cosmosDbContext;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> Handle(PuertaUpdateActivoCommand request, CancellationToken cancellationToken)
        {
            var p = _cosmosDbContext.Puertas.FirstOrDefault(x => x.Id == request.Id);

            if (p != null)
            {
                p.Activo = request.Activo;
                p.UltimoEstadoFecha = DateTime.UtcNow;

                _cosmosDbContext.Update(p);
                await _cosmosDbContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Se actualizó el id {p.Id}");

                //await _mediator.Publish(new PuertaUpdateEstadoDomainEvent { Id = request.Id });

            }

            return true;
        }
    }
}
