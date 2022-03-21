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
app.MapGet("/HighScores/GetAllUserData", ([FromServices] IHighScoreService inMemHigh) =>
{
    var result = inMemHigh.GetHighScoreList();
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByName/{name}", ([FromServices] IHighScoreService inMemHigh, [FromRoute] string name) =>
{
    var result = inMemHigh.GetSingleUserData(name);
    return Results.Ok(result);
});
<<<<<<< Updated upstream
=======

app.MapGet("/test", ([FromServices] IHighScoreService inMemHigh) =>
{
    var result = inMemHigh.GetHighScoreList();
    return Results.Ok(result);
});
>>>>>>> Stashed changes
#region
/*app.MapGet("/HighScores/SearchByAlias/{alias}", ([FromServices] IHighScoreService inMemHigh, [FromRoute] string alias) =>
{
    var result = inMemHigh.GetSingleUserDataByAlias(alias);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByScore/{highScore}", ([FromServices] IHighScoreService inMemHigh, [FromRoute] int highScore) =>
{
    var result = inMemHigh.GetHighscoreUserData(highScore);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByLevelCompleted/{levelCompleted}", ([FromServices] IHighScoreService inMemHigh, [FromRoute] int levelCompleted) =>
{
    var result = inMemHigh.GetLevelCompletedUserData(levelCompleted);
    return Results.Ok(result);
});

app.MapGet("/HighScores/GetHighScoreList/", ([FromServices] IHighScoreService inMemHigh) =>
{
    var orderedList = inMemHigh.GetHighScoreList();
    return orderedList;
});

app.MapGet("/HighScores/GetAverageHighScore", ([FromServices] IHighScoreService inMemHigh) =>
{
    var averageHighScore = inMemHigh.GetAverageHighScore();
    return Results.Ok(averageHighScore);
});*/
#endregion
#endregion

#region Put
app.MapPut("/HighScores", ([FromServices] IHighScoreService inMemHigh, [FromBody] UserData data) =>
{
    inMemHigh.UpdateSingleUserData(data);
});
#endregion

#region Post
app.MapPost("/HighScores", ([FromServices] IHighScoreService inMemHigh, [FromBody] UserData data) =>
{
    inMemHigh.AddSingleUserData(data);
    return Results.Created($"/HighScores/SearchByName/{data.Name}", data);
});

app.MapPost("/HighScores/AddMultipleUserData", ([FromServices] IHighScoreService inMemHigh, [FromBody] List<UserData> data) =>
{
    inMemHigh.AddMultipleUserData(data);
    return Results.Created($"/HighScores", data);
});
#endregion

#region Delete
app.MapDelete("HighScore/DeleteById/{id}", ([FromServices] IHighScoreService inMemHigh, [FromRoute] int id) =>
{
    inMemHigh.DeleteSingleUserDataById(id);
});
#endregion

app.Run();