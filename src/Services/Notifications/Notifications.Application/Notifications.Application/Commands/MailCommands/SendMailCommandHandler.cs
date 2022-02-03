using MediatR;
using Notifications.Infraestructure;
using Notifications.Infraestructure.SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Application.Commands.MailCommands
{
    public class SendMailCommandHandler : IRequestHandler<SendMailCommand, bool>
    {
        private readonly IMailService _sendMail;

        public SendMailCommandHandler(IMailService sendMail)
        {
            _sendMail = sendMail;
        }

        public async Task<bool> Handle(SendMailCommand request, CancellationToken cancellationToken)
        {
            await _sendMail.Send(new Domain.AggregatesModel.SendMailAggregate.Mail
            {
                From = request.From,
                To = request.To,
                Subject = request.Subject,
                Mensaje = request.Mensaje,
                MensajeHtml = request.MensajeHtml,


            });

            return true;
        }
    }
}
