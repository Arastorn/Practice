using System;
using MediatR;
using Practice.Core.Entities.DigimonAggregate;

namespace Practice.Core.Features.Digimons.Queries.GetDigimonById
{
    public class GetDigimonByIdQuery : IRequest<Digimon?>
    {
        public GetDigimonByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}