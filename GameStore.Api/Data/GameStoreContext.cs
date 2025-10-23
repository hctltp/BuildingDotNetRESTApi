using Microsoft.EntityFrameworkCore;
using GameStore.Api.Entities;
using System.Reflection;

namespace GameStore.Api.Data
{
    public class GameStoreContext : DbContext
    {
        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Games => Set<Game>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            /* base.OnModelCreating(modelBuilder);

            var game = modelBuilder.Entity<Game>();

            game.ToTable("Games");

            game.HasKey(g => g.Id);

            game.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            game.Property(g => g.Genre)
                .IsRequired()
                .HasMaxLength(20);

            game.Property(g => g.Price)
                .HasColumnType("decimal(18,2)");

            game.Property(g => g.ReleaseDate)
                .HasColumnType("date");

            game.Property(g => g.ImageUri)
                .HasMaxLength(100);

            // Seed initial data (optional)
            game.HasData(
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
            ); */
        }
    }
}