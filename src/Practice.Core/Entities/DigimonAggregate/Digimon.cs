using System;
using NodaTime;

namespace Practice.Core.Entities.DigimonAggregate
{
    public class Digimon
    {
        public Digimon(Guid id, string nom, int niveau, Instant createdAt, Instant updatedAt)
        {
            Id = id;
            Nom = nom;
            Niveau = niveau;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        private Digimon(string nom, int niveau, Instant createdAt, Instant updatedAt)
        {
            Nom = nom;
            Niveau = niveau;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        private Digimon()
        {
        }

        public Guid Id { get; }
        public string Nom { get; private set; } = default!;
        public int Niveau { get; private set; }
        public Instant CreatedAt { get; }
        public Instant UpdatedAt { get; private set; }

        public static Digimon Create(string nom, int niveau, Instant createdAt)
        {
            return new Digimon(nom, niveau, createdAt, createdAt);
        }

        public void Update(string nom, int niveau, Instant updatedAt)
        {
            Nom = nom;
            Niveau = niveau;
            UpdatedAt = updatedAt;
        }
    }
}