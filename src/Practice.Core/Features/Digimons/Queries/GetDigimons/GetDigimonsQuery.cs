using Practice.Core.Entities.DigimonAggregate;
using MediatR;
namespace Practice.Core.Features.Digimons.Queries.GetDigimons
{
    public class GetDigimonsQuery : IRequest<Digimon[]>
    {
        public GetDigimonsQuery()
        {
        }
    }
}