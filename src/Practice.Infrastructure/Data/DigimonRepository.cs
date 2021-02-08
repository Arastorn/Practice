using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using Practice.Core.Entities.DigimonAggregate;
using Practice.Core.Interfaces;

namespace Practice.Infrastructure.Data
{
    public class DigimonRepository : IDigimonRepository
    {
        private readonly IDbConnection connection;

        public DigimonRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<Digimon> Create(Digimon digimon, CancellationToken cancellationToken = default)
        {
            var id = await connection.QuerySingleOrDefaultAsync<Guid>(
                @"INSERT INTO digimons(nom, niveau, created_at, updated_at) 
                      VALUES (@Nom, @Niveau, @CreatedAt, @UpdatedAt)
                      RETURNING id;",
                digimon);

            return new Digimon(
                id,
                digimon.Nom,
                digimon.Niveau,
                digimon.CreatedAt,
                digimon.UpdatedAt);
        }

        public async Task Update(Digimon digimon)
        {
            var sql = @"UPDATE digimons 
                    SET nom = @Nom, niveau = @Niveau, updated_at = @UpdatedAt
                    WHERE id = @Id;";
            await connection.ExecuteAsync(
                sql,
                new
                {
                    nom = digimon.Nom,
                    niveau = digimon.Niveau,
                    UpdatedAt = digimon.UpdatedAt,
                    Id = digimon.Id
                });
        }

        public async Task<Digimon[]> GetDigimons() => (await connection.QueryAsync<Digimon>(@"SELECT * FROM digimons;")).ToArray();

        public async Task<Digimon?> GetDigimonById(Guid id) =>
            await connection.QueryFirstOrDefaultAsync<Digimon>(@"Select * FROM digimons WHERE id = @Id;", new { Id = id });
    }
}