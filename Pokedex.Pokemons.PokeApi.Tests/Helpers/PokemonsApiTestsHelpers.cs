using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Pokemons.PokeApi.Tests.Helpers
{
    public static class PokemonsApiTestsHelpers
    {
        /// <summary>
        /// Reads the contents of an embedded resource file
        /// </summary>
        /// <param name="resourceName">The name of the resource to read</param>
        /// <returns>The contents of the embedded resource</returns>
        public static async Task<string> ReadEmbeddedResourceAsString(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
