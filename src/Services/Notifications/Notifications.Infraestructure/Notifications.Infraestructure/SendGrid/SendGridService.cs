using Microsoft.Extensions.Configuration;
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
    public class SendGridService : IMailService
    {
        public SendGridService(IConfiguration configuration)
        {
            ApiKey = configuration["SendGrid:ApiKey"];
        }

        public readonly string ApiKey;
        
        public async Task Send(Mail mail)
        {
           //"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";
            var client = new SendGridClient(ApiKey);

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(mail.From),
                Subject = mail.Subject,
                PlainTextContent = mail.Mensaje,
                HtmlContent = mail.MensajeHtml
            };

            foreach (string t in mail.To.Split(";"))
            {
                if (t.Contains("@")) { msg.AddTo(new EmailAddress(t)); }
            }
            foreach (string c in mail.CC.Split(";"))
            {
                if (c.Contains("@")) { msg.AddCc(new EmailAddress(c)); }
            }
            foreach (string co in mail.CCo.Split(";"))
            {
                if (co.Contains("@")) { msg.AddBcc(new EmailAddress(co)); }
            }

            var response = await client.SendEmailAsync(msg).ConfigureAwait(false);
        }
    }
}
