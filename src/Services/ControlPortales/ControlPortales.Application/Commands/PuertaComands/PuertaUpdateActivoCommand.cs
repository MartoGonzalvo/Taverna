using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaComands
{
    public class PuertaUpdateActivoCommand : IRequest<bool>
    {
        public PuertaUpdateActivoCommand(string id, bool activo)
        {
            Id = id;
            Activo = activo;
        }

        [Required]
        public string Id { get; set; }
        public bool Activo { get; set; }
    }
}
