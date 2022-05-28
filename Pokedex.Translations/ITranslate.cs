using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Translations
{
    public interface ITranslate
    {
        /// <summary>
        /// Translates the provided text into the given language.
        /// </summary>
        /// <param name="text">The text to be translated</param>
        /// <param name="language">The language to translate into</param>
        /// <returns></returns>
        Task<string> Translate(string text, TranslationLanguage language);
    }

    public enum TranslationLanguage
    {
        Yoda,
        Shakespeare
    }
}
