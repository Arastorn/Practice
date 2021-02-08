using MediatR;
using Practice.Core.Entities.DigimonAggregate;

namespace Practice.Core.Features.Digimons.Commands.CreateDigimon
{
    public class CreateDigimonCommand : IRequest<Digimon>
    {
        public CreateDigimonCommand(string nom, int niveau)
        {
            Nom = nom;
            Niveau = niveau;
        }

        public string Nom { get; }
        public int Niveau { get; }
    }
}