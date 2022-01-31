using ControlPortales.Domain.Events;
using ControlPortales.Domain.Exceptions;
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
    public class PuertaUpdateEstadoCommandHandler : IRequestHandler<PuertaUpdateEstadoCommand, bool>
    {
        private readonly CosmosDbContext _cosmosDbContext;
        private IMediator _mediator;
        private ILogger<PuertaUpdateEstadoCommand> _logger;

        public PuertaUpdateEstadoCommandHandler(CosmosDbContext cosmosDbContext, IMediator mediator, ILogger<PuertaUpdateEstadoCommand> logger)
        {
            _cosmosDbContext = cosmosDbContext;
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<bool> Handle(PuertaUpdateEstadoCommand request, CancellationToken cancellationToken)
        {
            throw new DomainException("error", "complejo", "2");

            var p = _cosmosDbContext.Puertas.FirstOrDefault(x => x.Id == request.Id);

            if (p != null)
            {
                p.UltimoEstado = request.UltimoEstado;
                p.UltimoEstadoFecha = DateTime.UtcNow;

                _cosmosDbContext.Update(p);
                await _cosmosDbContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Se actualizó el id {p.Id}");

                await _mediator.Publish(new PuertaUpdateEstadoDomainEvent { Id = request.Id });

            }

            return true;
        }
    }
}
