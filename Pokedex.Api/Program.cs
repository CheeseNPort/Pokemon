using Pokedex.BusinessLogic;
using Pokedex.Pokemons;
using Pokedex.Pokemons.PokeApi;
using Pokedex.Translations;
using Pokedex.Translations.FunTranslationsApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Inject the cache
builder.Services.AddMemoryCache();

// Inject the poke API
builder.Services.AddHttpClient<IPokeApiCalls, PokeApiCalls>(client => client.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));
builder.Services.AddTransient<IPokemons>(x => new PokeApi(x.GetRequiredService<IPokeApiCalls>()));

// Inject the translations API
builder.Services.AddHttpClient<IFunTranslationsApiCalls, FunTranslationsApiCalls>(client => client.BaseAddress = new Uri("https://api.funtranslations.com/translate/"));
builder.Services.AddTransient<ITranslate>(x => new FunTranslationsApi(x.GetRequiredService<IFunTranslationsApiCalls>()));

// Inject the business logic
builder.Services.AddTransient<IPokedexBusinessLogic>(x => new PokedexBusinessLogic(x.GetRequiredService<IPokemons>(), x.GetRequiredService<ITranslate>()));

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
