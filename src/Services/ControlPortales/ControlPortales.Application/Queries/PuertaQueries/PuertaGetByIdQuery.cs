using ControlPortales.Application.Queries.PuertaQueries.QueryResults;
using MediatR;

namespace ControlPortales.Application.Queries.PuertaQueries
{
    public class PuertaGetByIdQuery : IRequest<PuertaGetByIdQueryResult>
    {
        public string Id { get; set; }
    }
}
