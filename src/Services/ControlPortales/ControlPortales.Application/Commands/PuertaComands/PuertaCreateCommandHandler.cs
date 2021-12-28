using ControlPortales.Domain.AggregatesModel.PuertaAggregate;
using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using System;

namespace ControlPortales.Application.Commands.PuertaCommands
{
    public class PuertaCreateCommandHandler : IRequestHandler<PuertaCreateCommand, bool>
    {
        private readonly CosmosDbContext _cosmosDbContext;
        private IMediator _mediator;

        public PuertaCreateCommandHandler(CosmosDbContext cosmosDbContext, IMediator mediator)
        {
            _cosmosDbContext = cosmosDbContext;
            _mediator = mediator;
        }

        public async Task<bool> Handle(PuertaCreateCommand request, CancellationToken cancellationToken)
        {
            _cosmosDbContext.Puertas.Add(new Puerta
            {
                Id = request.Id,
                PuertaName = request.PuertaName,
                Activo = request.Activo,
                AntenaIp = request.AntenaIp,
                AntenaPuerto = request.AntenaPuerto,
                CantidadMovimientoPuerta = request.CantidadMovimientoPuerta,
                Descripcion = request.Descripcion,
                UltimoEstado = request.UltimoEstado,
                UltimoEstadoFecha = request.UltimoEstadoFecha,
                Power = request.Power,
                RfidCleanId = request.RfidCleanId,
                RxSensbility = request.RxSensbility
            });

            await _cosmosDbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PuertaCreatedDomainEvent { Id = request.Id });

            return true;
        }
    }
}
