using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ControlPortales.Application.DomainEventHandlers.PuertaCreatedDomainEventHandlers
{
    public class SendMailWhenPuertaCreatedDomainEventHandler : INotificationHandler<PuertaCreatedDomainEvent>
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public SendMailWhenPuertaCreatedDomainEventHandler(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task Handle(PuertaCreatedDomainEvent notification, CancellationToken cancellationToken)
        {

           var puerta = await _cosmosDbContext.Puertas.SingleAsync(x => x.Id == notification.Id);

            if (puerta.UltimoEstado == 1) 
            {
                //Hacer algo
            }
            else
            {
                //hacer otra cosa
            }
        }
    }
}
