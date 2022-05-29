using Pokedex.BusinessLogic;
using Pokedex.Pokemons;
using Pokedex.Pokemons.PokeApi;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Inject the poke API
builder.Services.AddHttpClient<IPokeApiCalls, PokeApiCalls>(client => client.BaseAddress = new Uri("https://pokeapi.co/api/v2/"));
builder.Services.AddTransient<IPokemons>(x => new PokeApi(x.GetRequiredService<IPokeApiCalls>()));

// Inject the business logic
builder.Services.AddTransient<IPokedexBusinessLogic>(x => new PokedexBusinessLogic(x.GetRequiredService<IPokemons>(), null));

var app = builder.Build();
app.UseAuthorization();
app.MapControllers();
app.Run();
