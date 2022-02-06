using ControlPortales.Domain.Events;
using ControlPortales.Infraestructure.DataBase;
using ControlPortales.Infraestructure.Services.Services.Notifications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;


        public SendEmailWhenPuertaUpdateEstadoDomainEventHandler(CosmosDbContext cosmosDbContext, INotificationsService notificationService,IConfiguration configuration )
        {
            _cosmosDbContext = cosmosDbContext;
            _notificationService = notificationService;
            _configuration = configuration;
        }

        public async Task Handle(PuertaUpdateEstadoDomainEvent notification, CancellationToken cancellationToken)
        {

            var puerta = await _cosmosDbContext.Puertas.SingleAsync(x => x.Id == notification.Id);

            if (puerta.UltimoEstado == 0)
            {
                //Emitir alerta
                await _notificationService.SendMail(new Infraestructure.Services.Services.Notifications.Data.SendMailData
                {
                    From = _configuration.GetSection("Notifications").GetSection("PortalDesconectado").GetSection("Mail").GetSection("From").Value,
                    To = _configuration.GetSection("Notifications").GetSection("PortalDesconectado").GetSection("Mail").GetSection("To").Value,
                    Subject = _configuration.GetSection("Notifications").GetSection("PortalDesconectado").GetSection("Mail").GetSection("Subject").Value,
                    Mensaje = String.Format("El {1} se ha desconectado el portal {0}", puerta.Descripcion, puerta.UltimoEstadoFecha.ToLocalTime().ToString()),
                    CC = _configuration.GetSection("Notifications").GetSection("PortalDesconectado").GetSection("Mail").GetSection("Cc").Value,
                    CCo = _configuration.GetSection("Notifications").GetSection("PortalDesconectado").GetSection("Mail").GetSection("Cco").Value,
                    MensajeHtml = ""
                });

            }

        }
    }
}
