using TestApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHighScoreService, SQLiteHighScoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Get
app.MapGet("/HighScores/GetAllUserData", ([FromServices] IHighScoreService highScoreService) =>
{
    var result = highScoreService.GetHighScoreList();
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByName/{name}", ([FromServices] IHighScoreService highScoreService, [FromRoute] string name) =>
{
    var result = highScoreService.GetSingleUserData(name);
    return Results.Ok(result);
});
#region
/*app.MapGet("/HighScores/SearchByAlias/{alias}", ([FromServices] IHighScoreService highScoreService, [FromRoute] string alias) =>
{
    var result = highScoreService.GetSingleUserDataByAlias(alias);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByScore/{highScore}", ([FromServices] IHighScoreService highScoreService, [FromRoute] int highScore) =>
{
    var result = highScoreService.GetHighscoreUserData(highScore);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByLevelCompleted/{levelCompleted}", ([FromServices] IHighScoreService highScoreService, [FromRoute] int levelCompleted) =>
{
    var result = highScoreService.GetLevelCompletedUserData(levelCompleted);
    return Results.Ok(result);
});

app.MapGet("/HighScores/GetHighScoreList/", ([FromServices] IHighScoreService highScoreService) =>
{
    var orderedList = highScoreService.GetHighScoreList();
    return orderedList;
});

app.MapGet("/HighScores/GetAverageHighScore", ([FromServices] IHighScoreService highScoreService) =>
{
    var averageHighScore = highScoreService.GetAverageHighScore();
    return Results.Ok(averageHighScore);
});*/
#endregion
#endregion

#region Put
app.MapPut("/HighScores", ([FromServices] IHighScoreService highScoreService, [FromBody] UserData data) =>
{
    highScoreService.UpdateSingleUserData(data);
});
#endregion

#region Post
app.MapPost("/HighScores", ([FromServices] IHighScoreService highScoreService, [FromBody] UserData data) =>
{
    highScoreService.AddSingleUserData(data);
    return Results.Created($"/HighScores/SearchByName/{data.Name}", data);
});

app.MapPost("/HighScores/AddMultipleUserData", ([FromServices] IHighScoreService highScoreService, [FromBody] List<UserData> data) =>
{
    highScoreService.AddMultipleUserData(data);
    return Results.Created($"/HighScores", data);
});
#endregion

#region Delete
app.MapDelete("HighScore/DeleteById/{id}", ([FromServices] IHighScoreService highScoreService, [FromRoute] int id) =>
{
    highScoreService.DeleteSingleUserDataById(id);
});
#endregion

app.Run();