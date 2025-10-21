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

            gamesGroup.MapGet("/", (IGamesRepository repository) => repository.GetAll());

            gamesGroup.MapGet("/{id}", (IGamesRepository repository,int id) =>
            {
                Game? game = repository.Get(id);

                if (game is null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(game);

            }).WithName(GetGameEndpointName);

            gamesGroup.MapPost("/", (IGamesRepository repository, Game game) =>
            {
                repository.Create(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);

            });

            gamesGroup.MapPut("/{id}", (IGamesRepository repository, int id, Game updatedGame) =>
            {
                Game? existingGame = repository.Get(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUri = updatedGame.ImageUri;

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