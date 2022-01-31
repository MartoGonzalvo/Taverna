using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public string Title { get; set; }
        public string Type { get; set; }

        public DomainException(string message, string title, string type) : base(message)
        {
            Title = title;
            Type = type;
        }

        public DomainException(string message, Exception innerException)
           : base(message, innerException)
        { }
    }
}
