using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Domain.AggregatesModel.UsuarioAggregate
{
    public class LoginResponseDto
    {
        public int Id { get; set; }
        public string NombreUsuaurio { get; set; }
        public int idSucursal { get; set; }
        public int idEmpresa { get; set; }
    }
}
