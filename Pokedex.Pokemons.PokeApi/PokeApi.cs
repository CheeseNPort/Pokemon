using Pokedex.Pokemons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Pokemons.PokeApi
{
    public class PokeApi : IPokemons
    {
        private readonly IPokeApiCalls _pokeApiCalls;
        public PokeApi(IPokeApiCalls pokeApiCalls)
        {
            _pokeApiCalls = pokeApiCalls;
        }

        public async Task<Pokemon> GetPokemon(string name)
        {
            // Get the pokemon to determine its species
            var pokemon = await _pokeApiCalls.GetPokemon(name);
            var pokemonName = pokemon.RootElement.GetProperty("name").GetString();
            var speciesName = pokemon.RootElement.GetProperty("species").GetProperty("name").GetString();

            // Get the species as it contains more information we need for the response
            var species = await _pokeApiCalls.GetSpecies(speciesName);

            // Get the description from the flavor text entries
            var flavourTextEntries = species.RootElement.GetProperty("flavor_text_entries").EnumerateArray();
            var description = flavourTextEntries.FirstOrDefault(x => x.GetProperty("language").GetProperty("name").GetString() == "en").GetProperty("flavor_text").GetString();

            // Get the habitat
            var habitat = species.RootElement.GetProperty("habitat").GetProperty("name").GetString();

            // Get the legendary status
            var isLegendary = species.RootElement.GetProperty("is_legendary").GetBoolean();

            return new Pokemon(pokemonName, description, habitat, isLegendary);
        }

    }
}
