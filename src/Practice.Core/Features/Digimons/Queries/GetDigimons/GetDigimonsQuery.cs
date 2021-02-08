using MediatR;
using Practice.Core.Entities.DigimonAggregate;
namespace Practice.Core.Features.Digimons.Queries.GetDigimons
{
    public class GetDigimonsQuery : IRequest<Digimon[]>
    {
    }
}