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
                Id = request.id,
                PuertaName = request.puertaName,
                Activo = request.activo,
                AntenaIp = request.antenaIp,
                AntenaPuerto = request.antenaPuerto,
                CantidadMovimientoPuerta = request.cantidadMovimientoPuerta,
                Descripcion = request.descripcion,
                UltimoEstado = request.ultimoEstado,
                UltimoEstadoFecha = request.ultimoEstadoFecha,
                Power = request.power,
                RfidCleanId = request.rfidCleanId,
                RxSensitivity = request.rxSensitivity,
                SucursalId=request.sucursalId,
                ClienteId=request.clienteId,
                EmpresaId=request.empresaId,
                EsTolva= request.esTolva
            });

            await _cosmosDbContext.SaveChangesAsync(cancellationToken);

            await _mediator.Publish(new PuertaCreatedDomainEvent { Id = request.id });

            return true;
        }
    }
}
