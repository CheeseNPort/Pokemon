using System.Text.Json;

namespace Pokedex.Pokemons.PokeApi
{
    public interface IPokeApiCalls
    {
        /// <summary>
        /// Gets the pokemon itself from the poke API
        /// </summary>
        /// <param name="name">Name of the pokemon to get</param>
        /// <returns></returns>
        Task<JsonDocument> GetPokemon(string name);

        /// <summary>
        /// Gets the pokemon species from the poke API
        /// </summary>
        /// <param name="name">Name of the species to get</param>
        /// <returns></returns>
        Task<JsonDocument> GetSpecies(string name);
    }
}
