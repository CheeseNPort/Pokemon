using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokedex.BusinessLogic;
using Pokedex.Pokemons.Models;

namespace Pokedex.Api.Controllers
{
    [Route("pokemon")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokedexBusinessLogic _pokemonBusinessLogic;

        public PokemonController(IPokedexBusinessLogic pokemonBusinessLogic)
        {
            _pokemonBusinessLogic = pokemonBusinessLogic;
        }

        /// <summary>
        /// Get a pokemon given its name
        /// </summary>
        /// <typeparam name="Pokemon"></typeparam>
        /// <param name="name">Name of the pokemon to get</param>
        /// <returns>The pokemon matching the name provided</returns>
        [HttpGet("{name}")]
        public async Task<Pokemon> GetPokemon(string name)
        {
            var pokemon = await _pokemonBusinessLogic.GetPokemon(name);
            return pokemon;
        }

        /// <summary>
        /// Gets a pokemon with the description translated into yoda or shakespeare as required
        /// </summary>
        /// <param name="name">Name of the pokemon to get</param>
        /// <returns>The pokemon with a translated description</returns>
        [HttpGet("translated/{name}")]
        public async Task<Pokemon> GetPokemonTranslated(string name)
        {
            var pokemon = await _pokemonBusinessLogic.GetPokemonTranslated(name);
            return pokemon;
        }
    }
}
