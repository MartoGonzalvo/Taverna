using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.SendEmails
{
    public interface ISendEmails
    {
        Task Send(string titulo, string body, string[] destinatarios);
    }
}
