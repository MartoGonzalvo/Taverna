using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.Services.Services.Notifications.Data
{
    public class SendMailData
    {
        public string Subject { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string CC { get; set; }
        public string CCo { get; set; }
        public string Mensaje { get; set; }
        public string MensajeHtml { get; set; }
    }
}
