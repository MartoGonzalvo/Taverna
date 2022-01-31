using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.SendEmails
{
    public class SendGrindService : ISendEmails
    {
        public Task Send(string titulo, string body, string[] destinatarios)
        {
            throw new NotImplementedException();
        }
    }
}
