using System;
using NodaTime;

namespace Practice.Core.Tests.Entities
{
    using FluentAssertions;
    using Practice.Core.Entities.DigimonAggregate;
    using Xunit;

    [Trait("Category", "Unit")]
    public class DigimonShould
    {
        [Fact]
        public void CreateDigimon()
        {
            var instant = Instant.FromDateTimeOffset(new DateTimeOffset(2020, 3, 24, 11, 45, 0, TimeSpan.Zero));
            var digimon = Digimon.Create("Bakugon", 25, instant);
            digimon.Niveau.Should().Be(25);
            digimon.Nom.Should().Be("Bakugon");
        }
    }
}