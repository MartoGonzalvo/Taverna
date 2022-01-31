using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.DomainEventHandlers.PuertaUpdateEstadoDomainEventHandlers
{
    internal class SendEmailWhenPuertaUpdateEstadoDomainEventHandler : INotificationHandler<PuertaUpdateEstadoDomainEvent>
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public SendEmailWhenPuertaUpdateEstadoDomainEventHandler(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task Handle(PuertaUpdateEstadoDomainEvent notification, CancellationToken cancellationToken)
        {
            var puerta = await _cosmosDbContext.Puertas.SingleAsync(x => x.Id==notification.Id);

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
