using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlPortales.Domain.AggregatesModel.PuertaAggregate
{
    public class Puerta
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        public string PuertaName { get; set; }
        [JsonPropertyName("rfidCleanId")]
        public short? RfidCleanId { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("activo")]
        public bool? Activo { get; set; }
        [JsonPropertyName("antenaIp")]
        public string AntenaIp { get; set; }
        [JsonPropertyName("rxSensitivity")]
        public short? RxSensitivity { get; set; }
        [JsonPropertyName("sucursalId")]
        public short? SucursalId { get; set; }
        [JsonPropertyName("power")]
        public decimal Power { get; set; }
        [JsonPropertyName("antenaPuerto")]
        public string? AntenaPuerto { get; set; }
        [JsonPropertyName("ultimoEstado")]
        public byte? UltimoEstado { get; set; }
        [JsonPropertyName("ultimoEstadoFecha")]
        public DateTime UltimoEstadoFecha { get; set; }
        [JsonPropertyName("cantidadMovimientoPuerta")]
        public short? CantidadMovimientoPuerta { get; set; }
        [JsonPropertyName("clienteId")]
        public short? ClienteId { get; set; }
        [JsonPropertyName("empresaId")]
        public short? EmpresaId { get; set; }
        [JsonPropertyName("esTolva")]
        public bool? EsTolva { get; set; }
    }
}
