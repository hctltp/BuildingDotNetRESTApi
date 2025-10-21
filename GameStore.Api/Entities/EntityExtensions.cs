using GameStore.Api.Dtos;

namespace GameStore.Api.Entities
{
    public static class EntityExtensions
    {
        public static GameDto AsDto(this Game game)
        {
            return new GameDto(
                Id: game.Id,
                Name: game.Name,
                Genre: game.Genre,
                Price: game.Price,
                ReleaseDate: game.ReleaseDate,
                ImageUri: game.ImageUri
            );
        }
    }
}