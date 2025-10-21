using GameStore.Api.Dtos;
using GameStore.Api.Entities;
using GameStore.Api.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace GameStore.Api.Endpoints
{
    // Endpoint registrations for /games
    public static class GamesEndpoints
    {
        const string GetGameEndpointName = "GetGame";

       

        // Call this from Program.cs: app.MapGamesEndpoints();
        public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
        {

            

            // TODO: Define GET/POST/PUT/DELETE endpoints for Games here.
            var gamesGroup = routes.MapGroup("/games")
                                    .WithParameterValidation();

            gamesGroup.MapGet("/", (IGamesRepository repository) =>
                repository.GetAll().Select(game => game.AsDto()));

            gamesGroup.MapGet("/{id}", (IGamesRepository repository,int id) =>
            {
                Game? game = repository.Get(id);

                if (game is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(game.AsDto());

            }).WithName(GetGameEndpointName);

            gamesGroup.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUri = gameDto.ImageUri
                };

                repository.Create(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

            });

            gamesGroup.MapPut("/{id}", (IGamesRepository repository, int id, UpdateGameDto updatedGameDto) =>
            {
                Game? existingGame = repository.Get(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUri = updatedGameDto.ImageUri;

                repository.Update(existingGame);    

                return Results.NoContent();

            });

            gamesGroup.MapDelete("/{id}", (IGamesRepository repository, int id) =>
            {
                Game? game = repository.Get(id);

                if (game is not null)
                {
                    repository.Delete(id);
                }

                return Results.NoContent();
            });
            return gamesGroup;
        }
    }
}