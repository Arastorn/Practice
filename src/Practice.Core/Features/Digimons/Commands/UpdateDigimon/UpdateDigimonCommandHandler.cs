using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NodaTime;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Core.Features.Digimons.Commands.UpdateDigimon
{
    public class UpdateDigimonCommandHandler : IRequestHandler<UpdateDigimonCommand, Unit>
    {
        private readonly IDigimonRepository digimonRepository;
        private readonly IClock clock;

        public UpdateDigimonCommandHandler(IDigimonRepository digimonRepository, IClock clock)
        {
            this.digimonRepository = digimonRepository;
            this.clock = clock;
        }

        public async Task<Unit> Handle(UpdateDigimonCommand request, CancellationToken cancellationToken)
        {
            var digimon = await digimonRepository.GetDigimonById(request.Id);
            if (digimon != null)
            {
                digimon.Update(request.Nom, request.Niveau, clock.GetCurrentInstant());
                await digimonRepository.Update(digimon);
            }

            return Unit.Value;
        }
    }
}