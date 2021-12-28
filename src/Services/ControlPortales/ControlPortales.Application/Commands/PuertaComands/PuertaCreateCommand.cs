using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaCommands
{
    public class PuertaCreateCommand : IRequest<bool>
    {
        public PuertaCreateCommand(string id,string puertaName, short rfidCleanId, string descripcion, bool activo, string antenaIp, short rxSensbility, short sucursalId, decimal power, string antenaPuerto, byte ultimoEstado, DateTime ultimoEstadoFecha, short cantidadMovimientoPuerta)
        {
            Id = id;
            PuertaName = puertaName;
            RfidCleanId = rfidCleanId;
            Descripcion = descripcion;
            Activo = activo;
            AntenaIp = antenaIp;
            RxSensbility = rxSensbility;
            SucursalId = sucursalId;
            Power = power;
            AntenaPuerto = antenaPuerto;
            UltimoEstado = ultimoEstado;
            UltimoEstadoFecha = ultimoEstadoFecha;
            CantidadMovimientoPuerta = cantidadMovimientoPuerta;
        }

        [Required]
        public string Id { get; set; }
        public string PuertaName { get; set; }
        public short RfidCleanId { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string AntenaIp { get; set; }
        public short RxSensbility { get; set; }
        public short SucursalId { get; set; }
        public Decimal Power { get; set; }
        public string AntenaPuerto { get; set; }
        public byte UltimoEstado { get; set; }
        public DateTime UltimoEstadoFecha { get; set; }
        public short CantidadMovimientoPuerta { get; set; }
    }
}
