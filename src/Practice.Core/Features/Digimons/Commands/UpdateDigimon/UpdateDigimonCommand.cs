using System;
using MediatR;

namespace Practice.Core.Features.Digimons.Commands.UpdateDigimon
{
    public class UpdateDigimonCommand : IRequest<Unit>
    {
        public UpdateDigimonCommand(Guid id, string nom, int niveau)
        {
            Id = id;
            Nom = nom;
            Niveau = niveau;
        }

        public Guid Id { get; }
        public string Nom { get; }
        public int Niveau { get; }
    }
}