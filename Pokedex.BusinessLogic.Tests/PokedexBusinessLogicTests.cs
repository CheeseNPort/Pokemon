using Moq;
using Pokedex.Pokemons;
using Pokedex.Pokemons.Models;
using Pokedex.Translations;
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
            var correctPokemonName = "correctname";

            var pokemons = new Mock<IPokemons>();
            pokemons.Setup(x => x.GetPokemon(It.Is<string>(s => s == correctPokemonName))).ReturnsAsync(new Pokemon(correctPokemonName, "", "", false));
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).Throws<Exception>();

            var businessLogic = new PokedexBusinessLogic(pokemons.Object, null);

            // Act and Assert
            await Assert.ThrowsAsync<Exception>(() => businessLogic.GetPokemon("someothername"));
        }

        [Fact]
        public async Task GetPokemonTranslated_GettingLegendaryPokemon_TranslatesToYoda()
        {
            // Arrange
            var englishDescription = "Description in English";
            var yodaTranslation = "Description in Yoda";

            var pokemons = new Mock<IPokemons>();
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).ReturnsAsync(new Pokemon("", englishDescription, "", true));

            var translations = new Mock<ITranslate>();
            translations.Setup(x => x.Translate(It.Is<string>(s => s == englishDescription), It.Is<TranslationLanguage>(t => t == TranslationLanguage.Yoda))).ReturnsAsync(yodaTranslation);

            var businessLogic = new PokedexBusinessLogic(pokemons.Object, translations.Object);

            // Act
            var pokemon = await businessLogic.GetPokemonTranslated("");

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(yodaTranslation, pokemon.Description);
        }

        [Fact]
        public async Task GetPokemonTranslated_GettingCavePokemon_TranslatesToYoda()
        {
            // Arrange
            var englishDescription = "Description in English";
            var yodaTranslation = "Description in Yoda";

            var pokemons = new Mock<IPokemons>();
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).ReturnsAsync(new Pokemon("", englishDescription, "cave", false));

            var translations = new Mock<ITranslate>();
            translations.Setup(x => x.Translate(It.Is<string>(s => s == englishDescription), It.Is<TranslationLanguage>(t => t == TranslationLanguage.Yoda))).ReturnsAsync(yodaTranslation);

            var businessLogic = new PokedexBusinessLogic(pokemons.Object, translations.Object);

            // Act
            var pokemon = await businessLogic.GetPokemonTranslated("");

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(yodaTranslation, pokemon.Description);
        }

        [Fact]
        public async Task GetPokemonTranslated_GettingNonCaveNonLegendaryPokemon_TranslatesToShakespeare()
        {
            // Arrange
            var englishDescription = "Description in English";
            var shakespeareDescription = "Description in Shakespeare";

            var pokemons = new Mock<IPokemons>();
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).ReturnsAsync(new Pokemon("", englishDescription, "", false));

            var translations = new Mock<ITranslate>();
            translations.Setup(x => x.Translate(It.Is<string>(s => s == englishDescription), It.Is<TranslationLanguage>(t => t == TranslationLanguage.Shakespeare))).ReturnsAsync(shakespeareDescription);

            var businessLogic = new PokedexBusinessLogic(pokemons.Object, translations.Object);

            // Act
            var pokemon = await businessLogic.GetPokemonTranslated("");

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(shakespeareDescription, pokemon.Description);
        }

        [Fact]
        public async Task GetPokemonTranslated_WhenTranslationFails_KeepsDescriptionInEnglish()
        {
            // Arrange
            var englishDescription = "Description in English";

            var pokemons = new Mock<IPokemons>();
            pokemons.Setup(x => x.GetPokemon(It.IsAny<string>())).ReturnsAsync(new Pokemon("", englishDescription, "", true));

            var translations = new Mock<ITranslate>();
            translations.Setup(x => x.Translate(It.IsAny<string>(), It.IsAny<TranslationLanguage>())).Throws<Exception>();

            var businessLogic = new PokedexBusinessLogic(pokemons.Object, translations.Object);

            // Act
            var pokemon = await businessLogic.GetPokemonTranslated("");

            // Assert
            Assert.NotNull(pokemon);
            Assert.Equal(englishDescription, pokemon.Description);
        }
    }
}