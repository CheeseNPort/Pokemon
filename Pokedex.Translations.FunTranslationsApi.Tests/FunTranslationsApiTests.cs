using Moq;
using Pokedex.UnitTestHelpers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace Pokedex.Translations.FunTranslationsApi.Tests
{
    public class FunTranslationsApiTests
    {
        [Fact]
        public async Task Translate_TranslatingToYoda_TranslatesCorrectly()
        {
            // Arrange
            var apiCalls = new Mock<IFunTranslationsApiCalls>();
            var translationResponse = await PokedexUnitTestHelpers.ReadEmbeddedResourceAsString<FunTranslationsApiTests>("Pokedex.Translations.FunTranslationsApi.Tests.ValidTranslationResponse.json");
            var translationJson = JsonDocument.Parse(translationResponse);
            apiCalls.Setup(x => x.Translate(It.IsAny<string>(), It.Is<string>(s => s == "yoda"))).ReturnsAsync(translationJson);
            var translations = new FunTranslationsApi(apiCalls.Object);

            // Act
            var translatedText = await translations.Translate("english text", TranslationLanguage.Yoda);

            // Assert
            Assert.Equal("translated text", translatedText);
        }

        [Fact]
        public async Task Translate_TranslatingToShakespeare_TranslatesCorrectly()
        {
            // Arrange
            var apiCalls = new Mock<IFunTranslationsApiCalls>();
            var translationResponse = await PokedexUnitTestHelpers.ReadEmbeddedResourceAsString<FunTranslationsApiTests>("Pokedex.Translations.FunTranslationsApi.Tests.ValidTranslationResponse.json");
            var translationJson = JsonDocument.Parse(translationResponse);
            apiCalls.Setup(x => x.Translate(It.IsAny<string>(), It.Is<string>(s => s == "shakespeare"))).ReturnsAsync(translationJson);
            var translations = new FunTranslationsApi(apiCalls.Object);

            // Act
            var translatedText = await translations.Translate("english text", TranslationLanguage.Shakespeare);

            // Assert
            Assert.Equal("translated text", translatedText);
        }
    }
}