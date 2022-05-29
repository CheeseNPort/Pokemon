# Pokemon
## Design Idea
1. Interface to handle translations and implementation of the "Fun Translations" API, we'll call these projects Pokedex.Translations and Pokedex.Translations.FunTranslationsApi
2. Inerface to handle obtaining pokemnon information, and implementation of the "Poke" API, we'll call these projects Pokedex.Pokemons and Pokedex.Pokemons.PokeApi
3. Business logic layer to handle getting pokemons and when to translate etc., we'll call this project Pokedex.BusinessLogic
4. Asp.Net Core 6 Web API with pokemon controller, calling the business logic layer, we'll call this project Pokedex.Api
5. An in memory cache to cache the results of each API call for a set amount of time to speed up repeat API calls

## Running the application
1. Install Asp.Net CORE 6 SDK, which can be found at https://dotnet.microsoft.com/en-us/download/dotnet/6.0
2. In a command prompt, navigate to the Pokedox.Api folder
3. Run the following command
```dotnet run --urls=http://localhost:5000```

## Running the application as a docker container
1. Install dockerm which can be found at https://docs.docker.com/get-docker/
2. In a comand prompt, navigate to the root of this project
3. Run the following commands
```docker build -f Pokedex.Api/Dockerfile -t pokedex .```
```docker run -it --rm -p 5000:80 --name pokemon```