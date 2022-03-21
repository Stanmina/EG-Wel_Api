using TestApi;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IHighScoreService, SQLHighScoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Get
app.MapGet("/HighScores/GetAllUserData", ([FromServices] IHighScoreService hsService) =>
{
    var result = hsService.GetUserDatas();
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByName/{name}", ([FromServices] IHighScoreService hsService, [FromRoute] string name) =>
{
    var result = hsService.GetSingleUserData(name);
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
/*app.MapGet("/HighScores/SearchByAlias/{alias}", ([FromServices] IHighScoreService hsService, [FromRoute] string alias) =>
{
    var result = hsService.GetSingleUserDataByAlias(alias);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByScore/{highScore}", ([FromServices] IHighScoreService hsService, [FromRoute] int highScore) =>
{
    var result = hsService.GetHighscoreUserData(highScore);
    return Results.Ok(result);
});

app.MapGet("/HighScores/SearchByLevelCompleted/{levelCompleted}", ([FromServices] hsService highScoreService, [FromRoute] int levelCompleted) =>
{
    var result = hsService.GetLevelCompletedUserData(levelCompleted);
    return Results.Ok(result);
});

app.MapGet("/HighScores/GetHighScoreList/", ([FromServices] IHighScoreService hsService) =>
{
    var orderedList = hsService.GetHighScoreList();
    return orderedList;
});

app.MapGet("/HighScores/GetAverageHighScore", ([FromServices] IHighScoreService hsService) =>
{
    var averageHighScore = hsService.GetAverageHighScore();
    return Results.Ok(averageHighScore);
});*/
#endregion
#endregion

#region Put
app.MapPut("/HighScores", ([FromServices] IHighScoreService hsService, [FromBody] UserData data) =>
{
    hsService.UpdateSingleUserData(data);
});
#endregion

#region Post
app.MapPost("/HighScores", ([FromServices] IHighScoreService hsService, [FromBody] UserData data) =>
{
    hsService.AddSingleUserData(data);
    return Results.Created($"/HighScores/SearchByName/{data.Name}", data);
});

app.MapPost("/HighScores/AddMultipleUserData", ([FromServices] IHighScoreService hsService, [FromBody] List<UserData> data) =>
{
    hsService.AddMultipleUserData(data);
    return Results.Created($"/HighScores", data);
});
#endregion

#region Delete
app.MapDelete("HighScore/DeleteById/{id}", ([FromServices] IHighScoreService hsService, [FromRoute] int id) => {
    hsService.DeleteSingleUserDataById(id);
});
app.MapDelete("HighScore/DeleteByName/{name}", ([FromServices] IHighScoreService hsService, [FromRoute] string name) => {
    hsService.DeleteSingleUserDataByName(name);
});
#endregion

app.Run();