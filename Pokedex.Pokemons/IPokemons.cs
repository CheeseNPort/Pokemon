using Pokedex.Pokemons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Pokemons
{
    public interface IPokemons
    {
        /// <summary>
        /// Gets a pokemon by providing its name
        /// </summary>
        /// <param name="name">The name of the pokemon to get</param>
        /// <returns>The pokemon matching the name provided</returns>
        Task<Pokemon> GetPokemon(string name);
    }
}
