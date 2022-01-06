using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaComands
{
    public class PuertaUpdateEstadoCommand : IRequest<bool>
    {
        public PuertaUpdateEstadoCommand(string id, byte ultimoEstado)
        {
            Id = id;
            UltimoEstado = ultimoEstado;
        }

        [Required]
        public string Id { get; set; }
        public byte UltimoEstado { get; set; }
    }
}
