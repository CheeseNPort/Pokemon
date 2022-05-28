using Moq;
using Pokedex.Pokemons;
using Pokedex.Pokemons.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.BusinessLogic.Tests
{
    public class PokedexBusinessLogicTests
    {
        [Fact]
        public async Task GetPokemon_ProvidingCorrectName_ReturnsPokemon()
        {
            // Arrange
            var pokemons = new Mock<IPokemons>();
            var correctPokemonName = "correctname";
            pokemons.Setup(x => x.GetPokemon(It.Is<string>(s => s == correctPokemonName))).ReturnsAsync(new Pokemon(correctPokemonName, "", "", false));
            var businessLogic = new PokedexBusinessLogic(pokemons.Object, null);

            // Act
            var pokemon = await businessLogic.GetPokemon(correctPokemonName);

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(correctPokemonName, pokemon.Name);
        }

        [Fact]
        public async Task GetPokemon_ProvidingIncorrectName_ThrowsException()
        {
            // Arrange
            var pokemons = new Mock<IPokemons>();
            var correctPokemonName = "correctname";
            pokemons.Setup(x => x.GetPokemon(It.Is<string>(s => s == correctPokemonName))).ReturnsAsync(new Pokemon(correctPokemonName, "", "", false));
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).Throws<Exception>();
            var businessLogic = new PokedexBusinessLogic(pokemons.Object, null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => businessLogic.GetPokemon("someothername"));
        }
    }
}