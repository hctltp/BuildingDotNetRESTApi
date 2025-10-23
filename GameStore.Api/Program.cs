using GameStore.Api.Endpoints;
using GameStore.Api.Repositories;
using GameStore.Api.Data;




var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();


app.Run();
