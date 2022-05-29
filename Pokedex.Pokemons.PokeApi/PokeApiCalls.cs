using Pokedex.Pokemons.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Pokemons.PokeApi
{
    public class PokeApiCalls : IPokeApiCalls
    {
        private readonly HttpClient _httpClient;

        public PokeApiCalls(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Gets the pokemon itself from the poke API
        /// </summary>
        /// <param name="name">Name of the pokemon to get</param>
        /// <returns></returns>
        public async Task<JsonDocument> GetPokemon(string name) => await Get($"pokemon/{name}");

        /// <summary>
        /// Gets the species from the poke API
        /// </summary>
        /// <param name="name">Name of the species to get</param>
        /// <returns></returns>
        public async Task<JsonDocument> GetSpecies(string name) => await Get($"pokemon-species/{name}");

        /// <summary>
        /// Gets the JSON document from a specific URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private async Task<JsonDocument> Get(string url) 
        {
            var response = await _httpClient.GetAsync(url);

            // Check if the call was succesful
            if(!response.IsSuccessStatusCode)
            {
                if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    throw new PokemonNotFoundException();
                }
                else
                {
                    throw new Exception($"Pokemon resource not found with status code {response.StatusCode}");
                }
            }

            // Read the response and return
            var body = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(body);
            return json;
        }
    }
}
