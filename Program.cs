using MongoDB_Minmal_API_Example.Models;
using MongoDB_Minmal_API_Example.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<GameDatabaseSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddSingleton<GameService>();

builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Using Scalar for API References
    app.MapOpenApi();
    app.MapScalarApiReference();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();
}

app.MapGet("/games", async (GameService gamesService) => {
    var games = await gamesService.GetAsync();
    return games;
});

app.MapGet("/games/{id}", async (GameService gamesService, string id) =>
{
    var game = await gamesService.GetAsync(id);
    return game is null ? Results.NotFound() : Results.Ok(game);
});


app.MapPost("/games", async (GameService gamesService, Game game) => {
    try
    {
        await gamesService.CreateAsync(game);
        return Results.Created($"/games/{game.Id}", game);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});


app.MapPut("/games/{id}", async (GameService gamesService, string id, Game game) => {
    try
    {
        game.Id = id; // Ensure the game object's Id matches the URL
        await gamesService.UpdateAsync(id, game);
        return Results.Ok(game);
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});


app.MapDelete("/games/{id}", async (GameService gamesService, string id) => {
    try
    {
        await gamesService.RemoveAsync(id);
        return Results.Ok();
    }
    catch (Exception ex)
    {
        return Results.Problem(ex.Message);
    }
});

app.Run();
