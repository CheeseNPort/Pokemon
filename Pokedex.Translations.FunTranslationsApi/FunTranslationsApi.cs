using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Translations.FunTranslationsApi
{
    public class FunTranslationsApi : ITranslate
    {
        private readonly IFunTranslationsApiCalls _funTranslationsApiCalls;
        public FunTranslationsApi(IFunTranslationsApiCalls funTranslationsApiCalls)
        {
            _funTranslationsApiCalls = funTranslationsApiCalls;
        }

        public async Task<string> Translate(string text, TranslationLanguage language)
        {
            var translation = await _funTranslationsApiCalls.Translate(text, language.ToString().ToLower());
            var translatedText = translation.RootElement.GetProperty("contents").GetProperty("translated").GetString();
            return translatedText;
        }
    }
}
