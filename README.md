# Pokemon
## Design Idea
1. Interface to handle translations and implementation of the "Fun Translations" API, we'll call these projects Pokedox.Translations and Pokedox.Translations.FunTranslationsApi
2. Inerface to handle obtaining pokemnon information, and implementation of the "Poke" API, we'll call these projects Pokedox.Pokemons and Pokedox.Pokemons.PokeApi
3. Business logic layer to handle getting pokemons and when to translate etc., we'll call this project Pokedox.BusinessLogic
4. Asp.Net Core 6 Web API with pokemon controller, calling the business logic layer, we'll call this project Pokedox.Api
5. An in memory cache to cache the results of each API call for a set amount of time to speed up repeat API calls