using System.Threading.Tasks;
using Practice.Core.Entities.DigimonAggregate;

namespace Practice.Core.Interfaces
{
    public interface IDigimonRepository
    {
        void Create(Digimon digimon);
        Task Update(Digimon digimon);
        Digimon[] GetDigimons();
    }
}