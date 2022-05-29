using Microsoft.Extensions.Caching.Memory;

namespace Pokedex.Api.Helpers
{
    public static class CacheHelpers
    {
        /// <summary>
        /// Generates a key for the cache for storing a pokemon
        /// </summary>
        /// <param name="pokemonName">The name of the pokemon</param>
        /// <returns>A unique key for the cache, for the specified pokemon</returns>
        public static string GetPokemonKey(string pokemonName) => $"POKEMON-{pokemonName}";
        /// <summary>
        /// Generates a key for the cache for storing a translated pokemon
        /// </summary>
        /// <param name="pokemonName">The name of the pokemon</param>
        /// <returns>A unique key for the cache, for the specified pokemon</returns>
        public static string GetPokemonTranslatedKey(string pokemonName) => $"POKEMON-TRANSLATED-{pokemonName}";
    }
}
