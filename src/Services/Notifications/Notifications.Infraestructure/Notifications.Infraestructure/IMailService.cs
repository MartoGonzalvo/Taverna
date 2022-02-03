using Notifications.Domain.AggregatesModel.SendMailAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notifications.Infraestructure
{
    public interface IMailService
    {
        public Task Send(Mail mail);
    }
}
