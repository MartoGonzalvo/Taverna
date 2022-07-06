using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlPortales.Application.Commands.PuertaComands
{
    public class PuertaUpdateCommand : IRequest<bool>
    {
        [JsonConstructor]
        public PuertaUpdateCommand()
        {

        }
        public PuertaUpdateCommand(string id, string puertaName, short rfidCleanId, string descripcion, bool activo, string antenaIp, short rxSensitivity, short sucursalId, decimal power, string antenaPuerto, byte ultimoEstado, DateTime ultimoEstadoFecha, short cantidadMovimientoPuerta, short clienteId, short empresaId, bool esTolva)
        {
            Id = id;
            PuertaName = puertaName;
            RfidCleanId = rfidCleanId;
            Descripcion = descripcion;
            Activo = activo;
            AntenaIp = antenaIp;
            RxSensitivity = rxSensitivity;
            SucursalId = sucursalId;
            Power = power;
            AntenaPuerto = antenaPuerto;
            UltimoEstado = ultimoEstado;
            UltimoEstadoFecha = ultimoEstadoFecha;
            CantidadMovimientoPuerta = cantidadMovimientoPuerta;
            ClienteId = clienteId;
            EmpresaId = empresaId;
            EsTolva = esTolva;
        }

        [Required]
        public string Id { get; set; }
        public string PuertaName { get; set; }
        public short RfidCleanId { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public string AntenaIp { get; set; }
        public short RxSensitivity { get; set; }
        public short SucursalId { get; set; }
        public Decimal Power { get; set; }
        public string AntenaPuerto { get; set; }
        public byte UltimoEstado { get; set; }
        public DateTime UltimoEstadoFecha { get; set; }
        public short CantidadMovimientoPuerta { get; set; }
        public short? ClienteId { get; set; }
        public short? EmpresaId { get; set; }
        public bool EsTolva { get; set; }
    }
}
