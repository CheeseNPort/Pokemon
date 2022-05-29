using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pokedex.Translations.FunTranslationsApi
{
    public class FunTranslationsApiCalls : IFunTranslationsApiCalls
    {
        private readonly HttpClient _httpClient;
        public FunTranslationsApiCalls(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<JsonDocument> Translate(string text, string language)
        {
            var response = await _httpClient.PostAsync($"{language}.json", new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("text", text)
            }));
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(body);
            return json;
        }
    }
}
