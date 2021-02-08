using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NodaTime;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Core.Features.Digimons.Commands.CreateDigimon
{
    public class CreateDigimonCommandHandler : IRequestHandler<CreateDigimonCommand, Digimon>
    {
        private readonly IDigimonRepository digimonRepository;
        private readonly IClock clock;

        public CreateDigimonCommandHandler(IDigimonRepository digimonRepository, IClock clock)
        {
            this.digimonRepository = digimonRepository;
            this.clock = clock;
        }

        public async Task<Digimon> Handle(CreateDigimonCommand request, CancellationToken cancellationToken)
        {
            var currentDate = clock.GetCurrentInstant();
            var digimon = Digimon.Create(request.Nom, request.Niveau, currentDate);

            return await digimonRepository.Create(digimon, cancellationToken);
        }
    }
}