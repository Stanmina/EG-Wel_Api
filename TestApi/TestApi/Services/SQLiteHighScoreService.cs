namespace TestApi;

public class SQLiteHighScoreService/* : IHighScoreService*/
{
    private readonly SqliteDataAccess _database;

    public SQLiteHighScoreService() => _database = new SqliteDataAccess();

    public void AddMultipleUserData(List<UserData> data) => _database.PostMultipleUserData(data);

    public void AddSingleUserData(UserData data) => _database.PostSingleUserData(data);

    public bool DeleteSingleUserData(string name)
    {
        throw new NotImplementedException();
    }

    public void DeleteSingleUserDataById(int id) => _database.DeleteUserData(id);

    public void DeleteSingleUserDataByName(string name)
    {
        throw new NotImplementedException();
    }

    public double GetAverageHighScore()
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetHighScoreList() =>
        _database.GetHighScoreList($"SELECT * FROM UserData JOIN GameData ON UserData.Id = GameData.Id");

    public List<UserData> GetHighscoreUserData(int highScore)
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetLevelCompletedUserData(int levelCompleted)
    {
        throw new NotImplementedException();
    }

    public UserData? GetSingleUserData(string name) =>
        _database.GetUserData($"SELECT * FROM UserData JOIN GameData ON UserData.Id = GameData.Id WHERE UserData.Name = \"{name}\"").FirstOrDefault();


    public UserData? GetSingleUserDataByAlias(string alias)
    {
        throw new NotImplementedException();
    }

    public List<UserData> GetUserDatas() => _database.GetUserData("SELECT * FROM UserData");

    public void UpdateSingleUserData(UserData data) => _database.PutGameData(data);

    public void UpdateTimePlayedByName(string name, float time)
    {
        throw new NotImplementedException();
    }
}
