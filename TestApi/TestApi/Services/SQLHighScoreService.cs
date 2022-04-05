using TestApi.DataAccess;
using TestApi.Models;

namespace TestApi.Services;

public class SQLHighScoreService : IHighScoreService
{
    private readonly SqlDataAccess _database;

    public SQLHighScoreService(IConfiguration configuration)
    {
        _database = new SqlDataAccess(configuration);
    }

    public void AddMultipleUserData(List<UserData> data)
    {
        throw new NotImplementedException();
    }

    public void AddSingleUserData(UserData data)
    {
        _database.InsertIntoUserData($"TestDB.dbo.spInsertSingleUserData '{data.Name}', '{data.Alias}';", $"TestDB.dbo.spInsertSingleGameData {data.UserDataId}, {data.GameData.HighScore}, {data.GameData.LevelsCompleted}, {data.GameData.TimePlayed}");
    }

    public void DeleteSingleUserDataByName(string name)
    {
        _database.DeleteUserData($"TestDB.dbo.spDeleteSingleUserDataByName '{name}'");
    }

    public void DeleteSingleUserDataById(int id)
    {
        _database.DeleteUserData($"TestDB.dbo.spDeleteSingleUserData {id}");
    }

    public double GetAverageHighScore()
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetHighScoreList()
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetHighscoreUserData(int highScore)
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetLevelCompletedUserData(int levelCompleted)
    {
        throw new NotImplementedException();
    }

    public UserData? GetSingleUserData(string name)
    {
        return _database.GetUserData($"TestDB.dbo.GetAllByName {name};").FirstOrDefault();
    }

    public UserData? GetSingleUserDataByAlias(string alias)
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetUserDatas()
    {
        return _database.GetUserData("TestDB.dbo.spGetAllUserDataSortByTime");
    }

    public void UpdateSingleUserData(UserData data)
    {
        _database.UpdataData("");
    }

    public void UpdateTimePlayedByName(Time data)
    {
        _database.UpdataData($"TestDB.dbo.spInsertTimePlayedByName {data.name},{data.time};");
    }
}
