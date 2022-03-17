using TestApi;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(new InMemHighScoreService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Get
app.MapGet("/HighScores/GetAllUserData", ([FromServices] InMemHighScoreService inMemHigh) =>
{
    var result = inMemHigh.GetUserDatas();
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByName/{name}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] string name) =>
{
    var result = inMemHigh.GetSingleUserData(name);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByAlias/{alias}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] string alias) =>
{
    var result = inMemHigh.GetSingleUserDataByAlias(alias);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByScore/{highScore}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] int highScore) =>
{
    var result = inMemHigh.GetHighscoreUserData(highScore);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByLevelCompleted/{levelCompleted}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] int levelCompleted) =>
{
    var result = inMemHigh.GetLevelCompletedUserData(levelCompleted);
    return Results.Ok(result);
});

app.MapGet("/HighScores/GetHighScoreList/", ([FromServices] InMemHighScoreService inMemHigh/*[FromRoute] string name*/) =>
{
    var orderedList = inMemHigh.GetHighScoreList();
    return orderedList;
});

app.MapGet("/HighScores/GetAverageHighScore", ([FromServices] InMemHighScoreService inMemHigh) =>
{
    var averageHighScore = inMemHigh.GetAverageHighScore();
    return Results.Ok(averageHighScore);
});
#endregion

#region Put
app.MapPut("/HighScores", ([FromServices] InMemHighScoreService inMemHigh, [FromBody] UserData data) =>
{
    if (inMemHigh.UpdateSingleUserData(data))
        return Results.Created($"/HighScores/SearchByName/{data.Name}", data);
    else
        return Results.NotFound();
});
#endregion

#region Post
app.MapPost("/HighScores", ([FromServices] InMemHighScoreService inMemHigh, [FromBody] UserData data) =>
{
    inMemHigh.AddSingleUserData(data);
    return Results.Created($"/HighScores/SearchByName/{data.Name}", data);
});

app.MapPost("/HighScores/AddMultipleUserData", ([FromServices] InMemHighScoreService inMemHigh, [FromBody] List<UserData> data) =>
{
    inMemHigh.AddMultipleUserData(data);
    return Results.Created($"/HighScores", data);
});
#endregion

#region Delete
app.MapDelete("/HighScores/DeleteByName/{name}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] string name) =>
{
    if (inMemHigh.DeleteSingleUserData(name))
        return Results.NoContent();
    else
        return Results.NotFound();
});

app.MapDelete("HighScore/DeleteById/{id}", ([FromServices] InMemHighScoreService inMemHigh, [FromRoute] int id) =>
{
    inMemHigh.DeleteSingleUserData(id);
});
#endregion

app.Run();