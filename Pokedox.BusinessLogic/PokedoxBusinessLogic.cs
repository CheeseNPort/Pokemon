using Pokedox.Pokemons;
using Pokedox.Pokemons.Models;
using Pokedox.Translations;

namespace Pokedox.BusinessLogic
{
    public class PokedoxBusinessLogic : IPokedoxBusinessLogic
    {
        private readonly IPokemons _pokemons;
        private readonly ITranslate _translate;

        public PokedoxBusinessLogic(IPokemons pokemons, ITranslate translate)
        {
            _pokemons = pokemons;
            _translate = translate;
        }
        public async Task<Pokemon> GetPokemon(string name)
        {
            var pokemon = await _pokemons.GetPokemon(name);
            return pokemon;
        }

        public async Task<Pokemon> GetPokemonTranslated(string name)
        {
            var pokemon = await GetPokemon(name);
            await TranslatePokemonDescription(pokemon);
            return pokemon;
            
        }

        /// <summary>
        /// Translates the description of the pokemon to the required language
        /// </summary>
        /// <param name="pokemon">The pokemon to translate the desccription of</param>
        /// <returns>The pokemon with the translated description</returns>
        private async Task TranslatePokemonDescription(Pokemon pokemon)
        {
            var language = GetPokemonTranslationLanguage(pokemon);
            
            // Attempt to translate the description of the pokemon
            try
            {
                pokemon.Description = await _translate.Translate(pokemon.Description, language);
            }
            catch
            {
                // The translation failed, do nothing, just leave the description in English
            }
        }

        /// <summary>
        /// Detsermines which language a pokemon's description should be translated into
        /// </summary>
        /// <param name="pokemon">The pokemon in question</param>
        /// <returns>The language to translate the description into</returns>
        private TranslationLanguage GetPokemonTranslationLanguage(Pokemon pokemon) => (pokemon.Habitat == "cave" || pokemon.IsLegendary) ? TranslationLanguage.Yoda : TranslationLanguage.Shakespeare;

    }
}