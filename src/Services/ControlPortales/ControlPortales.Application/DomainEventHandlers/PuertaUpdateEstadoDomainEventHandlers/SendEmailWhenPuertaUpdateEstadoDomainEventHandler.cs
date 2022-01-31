using ControlPortales.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.DomainEventHandlers.PuertaUpdateEstadoDomainEventHandlers
{
    internal class SendEmailWhenPuertaUpdateEstadoDomainEventHandler : INotificationHandler<PuertaUpdateEstadoDomainEvent>
    {
        public Task Handle(PuertaUpdateEstadoDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
