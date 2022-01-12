using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.AggregatesModel.UsuarioAggregate
{
    public class LoginRequestDto
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
    }
}
