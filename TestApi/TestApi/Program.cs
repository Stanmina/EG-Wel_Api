using TestApi;
using Microsoft.AspNetCore.Mvc;
using TestApi.Services;
using TestApi.Models;
using TestApi.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*builder.Services.AddSingleton<IHighScoreService, InMemHighScoreService>();
builder.Services.AddSingleton<IHighScoreService, SQLiteHighScoreService>();*/
builder.Services.AddSingleton<IHighScoreService, SQLHighScoreService>();
builder.Services.AddSingleton<IScoreService, SQLScoreService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region TestDB
/*#region Get
app.MapGet("/HighScores/GetAllUserData", ([FromServices] IHighScoreService hsService) =>
{
    var result = hsService.GetUserDatas();
    return Results.Ok(result);
});
#endregion

#region Put
app.MapPut("/HighScores", ([FromServices] IHighScoreService hsService, [FromBody] UserData data) =>
{
    hsService.UpdateSingleUserData(data);
});

app.MapPut("/HighScores/UpdateTimePlayed", ([FromServices] IHighScoreService hsService, [FromBody] Time data) =>
{
    hsService.UpdateTimePlayedByName(data);
});
#endregion

#region Post
app.MapPost("/HighScores/AddNewUser", (HttpContext ctx, IHighScoreService hsService) => {
    // read value from Form collection
    var name = ctx.Request.Form["name"];
    var alias = ctx.Request.Form["alias"];

    hsService.AddSingleUserData(new User() { Name = name, Alias = alias });
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
*/
#endregion

#region EG-Wel_Spel_DB

app.MapGet("/Scores/GetByLevel/{levelName}", ([FromServices] IScoreService sService, [FromRoute] string levelName) => {
    Console.WriteLine(levelName);
    var result = sService.GetAllByLevel(levelName);
    return Results.Ok(result);
});

app.MapGet("/Scores/GetAllUsers", ([FromServices] IScoreService sService) => {
    var result = sService.GetAllUsers();
    return Results.Ok(result);
});

app.MapGet("/Scores/GetAllLevelsByUser{name}", ([FromServices] IScoreService sService, [FromRoute] string name) => {
    var result = sService.GetAllLevelsByUser(name);
    return Results.Ok(result);
});


app.MapGet("/Scores/GetUser{name}/{password}", ([FromServices] IScoreService sService, [FromRoute] string name, string password) => {
    var result = sService.GetUser(name, password);
    return Results.Ok(result);
});

app.MapPost("/Scores/InsertNewUser", (HttpContext ctx, IScoreService sService) => {
    var name = ctx.Request.Form["name"];
    var alias = ctx.Request.Form["alias"];
    var email = ctx.Request.Form["email"];
    var password = ctx.Request.Form["password"];

    sService.InsertNewUser(new User() { Name = name, Alias = alias, Email = email, Password = password });
});

app.MapPut("/Scores/PutTimeByLevel", ([FromServices] IScoreService sService, [FromBody] UpdateTime data) => {
    Console.WriteLine(data.time);
    sService.PutTime(data);
});

app.MapPost("/Scores/InsertNewTimeByLevel", (HttpContext ctx, IScoreService sService) => {
    sService.InsertNewTime(ctx.Request.Form["name"], ctx.Request.Form["level"], ctx.Request.Form["time"]);
});

#endregion
app.Run();