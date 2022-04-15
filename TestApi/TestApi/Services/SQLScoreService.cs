using TestApi.DataAccess;
using TestApi.Interfaces;
using TestApi.Models;
using TestApi.NewDataAccess;

namespace TestApi.Services;

public class SQLScoreService : IScoreService
{
    private readonly NewSqlDataAccess _database;

    public SQLScoreService(IConfiguration configuration) => _database = new NewSqlDataAccess(configuration);
    
    public List<Time> GetAllByLevel(string levelName) => _database.GetUserData($"[EG-Wel_Spel_DB].[dbo].[spGetTimeByLevel] '{levelName}'");

    public List<User> GetAllUsers() => _database.GetAllUsers("[EG-Wel_Spel_DB].[dbo].[spGetAllUsers]");
}
