using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Core.Features.Digimons.Queries.GetDigimons
{
    public class GetDigimonsQueryHandler : IRequestHandler<GetDigimonsQuery, Digimon[]>
    {
        private readonly IDigimonRepository digimonRepository;

        public GetDigimonsQueryHandler(IDigimonRepository digimonRepository)
        {
            this.digimonRepository = digimonRepository;
        }

        public async Task<Digimon[]> Handle(GetDigimonsQuery request, CancellationToken cancellationToken)
        {
            return digimonRepository.GetDigimons();
        }
    }
}