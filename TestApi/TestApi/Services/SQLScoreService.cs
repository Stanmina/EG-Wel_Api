using TestApi.DataAccess;
using TestApi.Interfaces;
using TestApi.Models;
using TestApi.NewDataAccess;

namespace TestApi.Services;

public class SQLScoreService : IScoreService
{
    private readonly NewSqlDataAccess _database;

    public SQLScoreService(IConfiguration configuration) => _database = new NewSqlDataAccess(configuration);
    
    public List<User> GetAllUsers() => _database.GetAllUsers("[EG-Wel_Spel_DB].[dbo].[spGetAllUsers]");

    public List<Time> GetAllByLevel(string levelName) => _database.GetUserData($"[EG-Wel_Spel_DB].[dbo].[spGetTimeByLevel] '{levelName}'");

    public void InsertNewUser(User data) => _database.Insert($"[EG-Wel_Spel_DB].[dbo].[spInsertNewUser] '{data.Name}', '{data.Alias}', '{data.Email}', '{data.Password}'");

    public void PutTime(UpdateTime data) => _database.PutTime($"[EG-Wel_Spel_DB].[dbo].[spUpdateTimeOnLevel] '{data.name}', '{data.level}', {data.time.ToString().Replace(',','.')}");

    public void InsertNewTime(string name, string level, string time) => _database.Insert($"[EG-Wel_Spel_DB].[dbo].[spInsertNewTime] '{name}', '{level}', {time}");

    public List<Level> GetAllLevelsByUser(string name) => _database.GetAllLevelsByUser($"[EG-Wel_Spel_DB].[dbo].[spGetAllLevelsByUser] '{name}'");

    bool IScoreService.GetUser(string name, string password)
    {
        Console.WriteLine($"[EG-Wel_Spel_DB].[dbo].[spGetUserByName] '{name}'");
        User data = _database.GetUser($"[EG-Wel_Spel_DB].[dbo].[spGetUserByName] '{name}'");

        if (data.Password == password)
            return true;
        else
            return false;
        
    }
}
