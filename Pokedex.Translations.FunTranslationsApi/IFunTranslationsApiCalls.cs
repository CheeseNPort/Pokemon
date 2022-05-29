using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Translations.FunTranslationsApi
{
    public interface IFunTranslationsApiCalls
    {
        Task<JsonDocument> Translate(string text, string language);
    }
}
