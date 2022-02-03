using ControlPortales.Infraestructure.Services.Services.Notifications.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Infraestructure.Services.Services.Notifications
{
    public interface INotificationsService
    {
        public Task SendMail(SendMailData data);
    }
}
