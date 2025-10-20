using GameStore.Api.Entities;

const string GetGameEndpointName = "GetGame";

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Predefined hardcoded games list using a C# List with additional fields
List<Game> games = new List<Game>
{
    new Game {
        Id = 1,
        Name = "The Legend of Zelda",
        Genre = "Adventure",
        Price = 59.99m,
        ReleaseDate = new DateTime(1986, 2, 21),
        ImageUri = "https://placehold.co/100"
    },
    new Game {
        Id = 2,
        Name = "Super Mario Bros.",
        Genre = "Platformer",
        Price = 49.99m,
        ReleaseDate = new DateTime(1985, 9, 13),
        ImageUri = "https://placehold.co/100"
    },
    new Game {
        Id = 3,
        Name = "Minecraft",
        Genre = "Sandbox",
        Price = 26.95m,
        ReleaseDate = new DateTime(2011, 11, 18),
        ImageUri = "https://placehold.co/100"
    }
};

var gamesGroup = app.MapGroup("/games")
    .WithParameterValidation();

gamesGroup.MapGet("/", () => games);

gamesGroup.MapGet("/{id}", (int id) =>
{
    Game? game = games.Find(game => game.Id == id);

    if (game is null)
    {
        return Results.NotFound();
    }

    return Results.Ok(game);

}).WithName(GetGameEndpointName);

gamesGroup.MapPost("/", (Game game) =>
{
    game.Id = games.Max(game => game.Id) + 1;

    games.Add(game);

    return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

});

gamesGroup.MapPut("/{id}", (int id, Game updatedGame) =>
{
    Game? existingGame = games.Find(game => game.Id == id);

    if (existingGame is null)
    {
        return Results.NotFound();
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUri = updatedGame.ImageUri;

    return Results.NoContent();

});

gamesGroup.MapDelete("/{id}", (int id) =>
{
     Game? game = games.Find(game => game.Id == id);

    if (game is not null)
    {
        games.Remove(game);
    }

    return Results.NoContent();
});


app.Run();
