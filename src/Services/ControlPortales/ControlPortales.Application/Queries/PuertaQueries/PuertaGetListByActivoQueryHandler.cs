using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using ControlPortales.Infraestructure.DataBase;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Queries.PuertaQueries
{
    public class PuertaGetListByActivoQueryHandler : IRequestHandler<PuertaGetListByActivoQuery,IEnumerable< PuertaGetListByActivoQueryResult>>
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public PuertaGetListByActivoQueryHandler(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async Task<IEnumerable<PuertaGetListByActivoQueryResult>> Handle(PuertaGetListByActivoQuery request, CancellationToken cancellationToken)
        {
            {
                var result =  _cosmosDbContext.Puertas.Select(x=>x);

                if (request.Activo != null)
                {
                    result = result.Where(x => x.Activo == request.Activo);
                }
                
                return result.Select(x=> new PuertaGetListByActivoQueryResult {
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
                    RxSensbility = x.RxSensbility
                }).ToList();
            }
        }
    }
}
