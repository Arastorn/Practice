using System;

namespace Practice.Core.Entities.DigimonAggregate
{
    public class Digimon
    {
        private Digimon(Guid id, string nom, int niveau)
        {
            Id = id;
            Nom = nom;
            Niveau = niveau;
        }

        public Guid Id { get; }
        public string Nom { get; }
        public int Niveau { get; }

        public static Digimon Create(string nom, int niveau)
        {
            return new Digimon(new Guid(), nom, niveau);
        }
    }
}