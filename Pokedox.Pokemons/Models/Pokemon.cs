using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedox.Pokemons.Models
{
    public class Pokemon
    {
        public Pokemon(string name, string description, string habitat, bool isLegendary)
        {
            Name = name;
            Description = description;
            Habitat = habitat;
            IsLegendary = isLegendary;
        }

        /// <summary>
        /// Name of the pokemon
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description of the pokemon
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// The habitat this Pokemon species can be encountered in
        /// </summary>
        public string Habitat { get; set; }
        /// <summary>
        /// Whether or not this is a legendary Pokemon.
        /// </summary>
        public bool IsLegendary { get; set; }
    }
}
