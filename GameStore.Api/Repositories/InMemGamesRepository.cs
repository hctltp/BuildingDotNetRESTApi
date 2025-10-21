using GameStore.Api.Entities;

namespace GameStore.Api.Repositories
{

    public class InMemGamesRepository : IGamesRepository
    {
        private readonly List<Game> games = new List<Game>
        {
            new Game
            {
                Id = 1,
                Name = "The Legend of Zelda",
                Genre = "Adventure",
                Price = 59.99m,
                ReleaseDate = new DateTime(1986, 2, 21),
                ImageUri = "https://placehold.co/100"
            },

            new Game
            {
                Id = 2,
                Name = "Super Mario Bros.",
                Genre = "Platformer",
                Price = 49.99m,
                ReleaseDate = new DateTime(1985, 9, 13),
                ImageUri = "https://placehold.co/100"
            },

            new Game
            {
                Id = 3,
                Name = "Minecraft",
                Genre = "Sandbox",
                Price = 26.95m,
                ReleaseDate = new DateTime(2011, 11, 18),
                ImageUri = "https://placehold.co/100"
            }
        };


        public IEnumerable<Game> GetAll()
        {
            return games;
        }

        public Game? Get(int id)
        {
            return games.Find(game => game.Id == id);
        }

        public void Create(Game game)
        {
            game.Id = games.Max(game => game.Id) + 1;

            games.Add(game);
        }

        public void Update(Game updatedGame)
        {
            var index = games.FindIndex(game => game.Id == updatedGame.Id);

            games[index] = updatedGame;
        }


        public void Delete(int id)
        {
            var index = games.FindIndex(game => game.Id == id);
            games.RemoveAt(index);
        }

    }
}