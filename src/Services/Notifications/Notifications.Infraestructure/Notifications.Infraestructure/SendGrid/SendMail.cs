using Notifications.Domain.AggregatesModel.SendMailAggregate;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Infraestructure.SendGrid
{
    public class SendMail : IMail
    {
        public async Task Send(Mail mail)
        {
            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress(mail.From);
            var subject = mail.Subject;
            var to = new EmailAddress(mail.To);
            var plainTextContent = mail.Mensaje;
            var htmlContent = mail.MensajeHtml;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
