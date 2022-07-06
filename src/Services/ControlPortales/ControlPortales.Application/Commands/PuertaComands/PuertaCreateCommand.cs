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
        //public PuertaCreateCommand(string _id,string _puertaName, short _rfidcleanId, string _descripcion, bool _activo, string _antenaIp, short _rxSensitivity, short _sucursalId, decimal _power, string _antenaPuerto, byte _ultimoEstado, DateTime _ultimoEstadoFecha, short _cantidadMovimientosPuerta, short _clienteId, short _empresaId)
        //{
        //    id = _id;
        //    puertaName = _puertaName;
        //    rfidCleanId = _rfidcleanId;
        //    descripcion = _descripcion;
        //    activo = _activo;
        //    antenaIp = _antenaIp;
        //    rxSensitivity = _rxSensitivity;
        //    sucursalId = _sucursalId;
        //    power = _power;
        //    antenaPuerto = _antenaPuerto;
        //    ultimoEstado = _ultimoEstado;
        //    ultimoEstadoFecha = _ultimoEstadoFecha;
        //    cantidadMovimientoPuerta = _cantidadMovimientosPuerta;
        //    clienteId = _clienteId;
        //    empresaId = _empresaId;
        //}

        [Required]
        public string id { get; set; }
        public string puertaName { get; set; }
        public short rfidCleanId { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public string antenaIp { get; set; }
        public short rxSensitivity { get; set; }
        public short sucursalId { get; set; }
        public Decimal power { get; set; }
        public string antenaPuerto { get; set; }
        public byte ultimoEstado { get; set; }
        public DateTime ultimoEstadoFecha { get; set; }
        public short cantidadMovimientoPuerta { get; set; }
        public short? clienteId { get; set; }
        public short? empresaId { get; set; }
        public Boolean esTolva { get; set; }
    }
}
