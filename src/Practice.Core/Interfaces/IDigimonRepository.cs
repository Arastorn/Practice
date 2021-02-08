using System;
using System.Threading;
using System.Threading.Tasks;
using Practice.Core.Entities.DigimonAggregate;

namespace Practice.Core.Interfaces
{
    public interface IDigimonRepository
    {
        Task<Digimon> Create(Digimon digimon, CancellationToken cancellationToken);
        Task Update(Digimon digimon);
        Task<Digimon[]> GetDigimons();
        Task<Digimon?> GetDigimonById(Guid id);
    }
}