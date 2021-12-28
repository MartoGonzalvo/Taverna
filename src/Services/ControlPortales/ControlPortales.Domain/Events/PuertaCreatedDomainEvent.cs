using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.Events
{
    public class PuertaCreatedDomainEvent : INotification
    {
        public string Id { get; set; }
    }
}
