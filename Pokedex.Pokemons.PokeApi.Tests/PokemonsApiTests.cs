using Moq;
using Pokedex.UnitTestHelpers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Pokemons.PokeApi.Tests
{
    public class PokeApiTests
    {
        
        [Fact]
        public async Task GetPokemon_PassingCorrectName_ReturnsPokemon()
        {
            // Arrange
            var pokemonName = "pokemon1";
            var speciesName = "species1";
            var pokemonResponse = await PokedexUnitTestHelpers.ReadEmbeddedResourceAsString<PokeApiTests>("Pokedex.Pokemons.PokeApi.Tests.ValidPokemonJsonResponse.json");
            var pokemonJson = JsonDocument.Parse(pokemonResponse);
            var speciesResponse = await PokedexUnitTestHelpers.ReadEmbeddedResourceAsString<PokeApiTests>("Pokedex.Pokemons.PokeApi.Tests.ValidSpeciesJsonResponse.json");
            var speciesJson = JsonDocument.Parse(speciesResponse);
            var pokeApiCalls = new Mock<IPokeApiCalls>();
            pokeApiCalls.Setup(x => x.GetPokemon(It.Is<string>(s => s == pokemonName))).ReturnsAsync(pokemonJson);
            pokeApiCalls.Setup(x => x.GetSpecies(It.Is<string>(s => s == speciesName))).ReturnsAsync(speciesJson);
            var pokeApi = new PokeApi(pokeApiCalls.Object);

            // Act
            var pokemon = await pokeApi.GetPokemon(pokemonName);

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(pokemonName, pokemon.Name);
            Assert.True(pokemon.IsLegendary);
            Assert.Equal("habitat1", pokemon.Habitat);
            Assert.Equal("description1", pokemon.Description);
        }

        
    }
}