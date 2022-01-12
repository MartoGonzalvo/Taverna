using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlPortales.Application.Queries.PuertaQueries
{
    public class PuertaGetListByClienteQuery: IRequest<IEnumerable<PuertaGetListByClienteQueryResult>>
    {
        public int idCliente { get; set; }
    }
}
