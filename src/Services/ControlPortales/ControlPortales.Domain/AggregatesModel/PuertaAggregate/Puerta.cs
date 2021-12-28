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
        [JsonPropertyName("rfidclean_id")]
        public short? RfidCleanId { get; set; }
        [JsonPropertyName("descripcion")]
        public string Descripcion { get; set; }
        [JsonPropertyName("activo")]
        public bool? Activo { get; set; }
        [JsonPropertyName("antena_ip")]
        public string AntenaIp { get; set; }
        [JsonPropertyName("rxsensitivity")]
        public short? RxSensbility { get; set; }
        [JsonPropertyName("sucursal_id")]
        public short? SucursalId { get; set; }
        [JsonPropertyName("power")]
        public decimal Power { get; set; }
        [JsonPropertyName("antena_puerto")]
        public string? AntenaPuerto { get; set; }
        [JsonPropertyName("ultimo_estado")]
        public byte? UltimoEstado { get; set; }
        [JsonPropertyName("ultimo_estado_fecha")]
        public DateTime UltimoEstadoFecha { get; set; }
        [JsonPropertyName("cantidad_movimientos_puerta")]
        public short? CantidadMovimientoPuerta { get; set; }
    }
}
