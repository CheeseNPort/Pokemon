using System.Reflection;

namespace Pokedex.UnitTestHelpers
{
    public static class PokedexUnitTestHelpers
    {
        /// <summary>
        /// Reads the contents of an embedded resource file
        /// </summary>
        /// <typeparam name="T">A type from the assembly containing the resource</typeparam>
        /// <param name="resourceName">The name of the resource to read</param>
        /// <returns>The contents of the embedded resource</returns>
        /// 
        public static async Task<string> ReadEmbeddedResourceAsString<T>(string resourceName)
        {
            var assembly = Assembly.GetAssembly(typeof(T));
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}