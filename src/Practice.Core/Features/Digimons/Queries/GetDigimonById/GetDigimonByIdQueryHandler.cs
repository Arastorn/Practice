using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Core.Features.Digimons.Queries.GetDigimonById
{
    public class GetDigimonByIdQueryHandler : IRequestHandler<GetDigimonByIdQuery, Digimon?>
    {
        private readonly IDigimonRepository digimonRepository;

        public GetDigimonByIdQueryHandler(IDigimonRepository digimonRepository)
        {
            this.digimonRepository = digimonRepository;
        }

        public async Task<Digimon?> Handle(GetDigimonByIdQuery request, CancellationToken cancellationToken) =>
            await digimonRepository.GetDigimonById(request.Id);
    }
}