using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.AggregatesModel.UsuarioAggregate
{
    public class TokenDto
    {
        public string Token { get; set; }
        public int idSucursal { get; set; }
    }
}
