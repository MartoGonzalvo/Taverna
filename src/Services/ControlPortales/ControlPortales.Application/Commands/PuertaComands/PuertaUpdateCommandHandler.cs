using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaComands
{
    public class PuertaUpdateCommandHandler : IRequestHandler<PuertaUpdateCommand, bool>
    {
        private readonly CosmosDbContext _cosmosDbContext;
        private IMediator _mediator;

        public PuertaUpdateCommandHandler(CosmosDbContext cosmosDbContext, IMediator mediator)
        {
            _cosmosDbContext = cosmosDbContext;
            _mediator = mediator;
        }

        public async Task<bool> Handle(PuertaUpdateCommand request, CancellationToken cancellationToken)
        {
            var p = _cosmosDbContext.Puertas.FirstOrDefault(x => x.Id == request.Id);

            if(p!= null)
            {
                p.Id = request.Id;
                p.PuertaName = p.PuertaName;
                p.Activo = request.Activo;
                p.AntenaIp = request.AntenaIp;
                p.AntenaPuerto = request.AntenaPuerto;
                p.CantidadMovimientoPuerta = request.CantidadMovimientoPuerta;
                p.Descripcion = request.Descripcion;
                p.UltimoEstado = request.UltimoEstado;
                p.UltimoEstadoFecha = request.UltimoEstadoFecha;
                p.Power = request.Power;
                p.RfidCleanId = request.RfidCleanId;
                p.RxSensbility = request.RxSensbility;

                _cosmosDbContext.Update(p);
                await _cosmosDbContext.SaveChangesAsync(cancellationToken);

                await _mediator.Publish(new PuertaUpdateDomainEvent { Id = request.Id });
                
            }

            return true;
        }
    }
}
