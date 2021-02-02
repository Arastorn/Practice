using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Infrastructure.InMemory
{
    public class DigimonRepository : IDigimonRepository
    {
        private List<Digimon> Digimons = new List<Digimon>()
        {
            Digimon.Create("Ragumon", 1)
        };
        
        public void Create(Digimon digimon)
        {
            Digimons.Add(digimon);
        }

        public Task Update(Digimon digimon)
        {
            throw new System.NotImplementedException();
        }

        public Digimon[] GetDigimons()
        {
            return Digimons.ToArray();
        }
    }
}