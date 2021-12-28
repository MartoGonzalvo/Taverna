using ControlPortales.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.DomainEventHandlers.PuertaCreatedDomainEventHandlers
{
    public class CreateLogWhenPuertaCreatedDomainEventHandler : INotificationHandler<PuertaCreatedDomainEvent>
    {
        public async Task Handle(PuertaCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //Logica de crear un log de la puerta creada
        }
    }
}
