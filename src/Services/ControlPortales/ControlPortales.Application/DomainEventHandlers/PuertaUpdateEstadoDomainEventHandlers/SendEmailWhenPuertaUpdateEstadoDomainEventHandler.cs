using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using ControlPortales.Infraestructure.Services.Services.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.DomainEventHandlers.PuertaUpdateEstadoDomainEventHandlers
{
   
    public class SendEmailWhenPuertaUpdateEstadoDomainEventHandler : INotificationHandler<PuertaUpdateEstadoDomainEvent>
    {
        private readonly CosmosDbContext _cosmosDbContext;
        private readonly INotificationsService _notificationService;

        public SendEmailWhenPuertaUpdateEstadoDomainEventHandler(CosmosDbContext cosmosDbContext, INotificationsService notificationService)
        {
            _cosmosDbContext = cosmosDbContext;
            _notificationService = notificationService;
        }

        public async Task Handle(PuertaUpdateEstadoDomainEvent notification, CancellationToken cancellationToken)
        {

            var puerta = await _cosmosDbContext.Puertas.SingleAsync(x => x.Id == notification.Id);

            if (puerta.UltimoEstado == 0)
            {
                //Emitir alerta
                await _notificationService.SendMail(new Infraestructure.Services.Services.Notifications.Data.SendMailData
                {
                    From = "no_responder@rfidclean.com.ar",
                    To = "ddeconomia@gmail.com",
                    Subject = "Portal desconectado",
                    Mensaje = String.Format("Se ha desconectado el portal {0}", puerta.Descripcion),
                    CC="",
                    CCo="",
                    MensajeHtml=""
                });

            }

        }
    }
}
