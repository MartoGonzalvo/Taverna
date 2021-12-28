﻿using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
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
    public class PuertaGetByIdQueryHandler : IRequestHandler<PuertaGetByIdQuery, PuertaGetByIdQueryResult>
    {
        private readonly CosmosDbContext _cosmosDbContext;

        public PuertaGetByIdQueryHandler(CosmosDbContext cosmosDbContext)
        {
            _cosmosDbContext = cosmosDbContext;
        }

        public async  Task<PuertaGetByIdQueryResult> Handle(PuertaGetByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _cosmosDbContext.Puertas.SingleAsync(x=>x.Id == request.Id);

            return new PuertaGetByIdQueryResult {
                Id = result.Id,
                PuertaName = result.PuertaName,
                Activo = result.Activo,
                AntenaIp = result.AntenaIp,
                AntenaPuerto = result.AntenaPuerto,
                CantidadMovimientoPuerta = result.CantidadMovimientoPuerta,
                Descripcion = result.Descripcion,
                UltimoEstado = result.UltimoEstado,
                UltimoEstadoFecha = result.UltimoEstadoFecha,
                Power = result.Power,
                RfidCleanId = result.RfidCleanId,
                RxSensbility = result.RxSensbility
            };
        }
    }
}