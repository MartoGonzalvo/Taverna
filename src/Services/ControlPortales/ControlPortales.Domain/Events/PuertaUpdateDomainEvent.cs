using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.Events
{
    public class PuertaUpdateDomainEvent : INotification
    {
        public string Id { get; set; }
    }
}
