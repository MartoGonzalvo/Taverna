using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Queries.PuertaQueries
{
    public class PuertaGetListByClienteQueryHandler : IRequestHandler<PuertaGetListByClienteQuery, IEnumerable<PuertaGetListByClienteQueryResult>>
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public PuertaGetListByClienteQueryHandler(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task<IEnumerable<PuertaGetListByClienteQueryResult>> Handle(PuertaGetListByClienteQuery request, CancellationToken cancellationToken)
        {
            var result = _cosmosDbContext.Puertas.Where(x => x.ClienteId == request.idCliente);

            return result.Select(x => new PuertaGetListByClienteQueryResult
            {
                Id = x.Id,
                PuertaName = x.PuertaName,
                Activo = x.Activo,
                AntenaIp = x.AntenaIp,
                AntenaPuerto = x.AntenaPuerto,
                CantidadMovimientoPuerta = x.CantidadMovimientoPuerta,
                Descripcion = x.Descripcion,
                UltimoEstado = x.UltimoEstado,
                UltimoEstadoFecha = x.UltimoEstadoFecha,
                Power = x.Power,
                RfidCleanId = x.RfidCleanId,
                RxSensitivity = x.RxSensitivity,
                ClienteId=x.ClienteId,
                EmpresaId=x.EmpresaId,
                SucursalId=x.SucursalId,
                EsTolva = x.EsTolva != null ? x.EsTolva : false,
                EsSegundaLectura = x.EsSegundaLectura != null ? x.EsSegundaLectura : false

            }).ToList();

        }
    }
}
