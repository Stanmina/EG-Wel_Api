namespace TestApi;

public class InMemHighScoreService/* : IHighScoreService*/
{
    private List<UserData> userDatas;

    public InMemHighScoreService()
    {
        this.userDatas = new()
        {
            new UserData { UserDataId = 1, Name = "Stan", Alias = "Stanmina", GameData = new() { HighScore = 69, LevelsCompleted = 2, TimePlayed = 60 } },
            new UserData { UserDataId = 2, Name = "Rens", Alias = "Wijlander", GameData = new() { HighScore = 420, LevelsCompleted = 1, TimePlayed = 254 } },
            new UserData { UserDataId = 3, Name = "Boyd", Alias = "Eliogat", GameData = new() { HighScore = 666, LevelsCompleted = 3, TimePlayed = 375 } },
            new UserData { UserDataId = 4, Name = "Angela", Alias = "Ansje", GameData = new() { HighScore = 69, LevelsCompleted = 1, TimePlayed = 569 } },
            new UserData { UserDataId = 5, Name = "Wendy", Alias = "MegaWendy", GameData = new() { HighScore = 420, LevelsCompleted = 2, TimePlayed = 824 } },
            new UserData { UserDataId = 6, Name = "Emily", Alias = "Emi", GameData = new() { HighScore = 69, LevelsCompleted = 2, TimePlayed = 951 } },
            new UserData { UserDataId = 7, Name = "Abigail", Alias = "Abi", GameData = new() { HighScore = 420, LevelsCompleted = 1, TimePlayed = 165 } },
            new UserData { UserDataId = 8, Name = "Lars", Alias = "Larsie", GameData = new() { HighScore = 666, LevelsCompleted = 3, TimePlayed = 497 } },
            new UserData { UserDataId = 9, Name = "Emiel", Alias = "EmielDebiel", GameData = new() { HighScore = 69, LevelsCompleted = 1, TimePlayed = 795 } },
            new UserData { UserDataId = 10, Name = "Luuk", Alias = "Franky", GameData = new() { HighScore = 420, LevelsCompleted = 2, TimePlayed = 166 } }
        };
    }

    public List<UserData> GetUserDatas() => userDatas;

    public UserData? GetSingleUserData(string name) => userDatas.Find((x) => x.Name == name);

    public UserData? GetSingleUserDataByAlias(string alias) => userDatas.Find((x) => x.Alias == alias);

    public List<UserData> GetHighscoreUserData(int highScore) => userDatas.FindAll((x) => x.GameData?.HighScore == highScore);

    public List<UserData> GetLevelCompletedUserData(int levelCompleted) => userDatas.FindAll((x) => x.GameData?.LevelsCompleted == levelCompleted);

    public List<UserData> GetHighScoreList()
    {
        List<UserData> orderList = userDatas;
        orderList = orderList.OrderByDescending(x => x.GameData?.HighScore).ThenBy(x => x.GameData?.TimePlayed).ToList();
        return orderList;
    }

    public double GetAverageHighScore()
    {
        double averageHighScore;
        averageHighScore = userDatas.Average(x => x.GameData.HighScore);
        return averageHighScore;
    }

    public bool DeleteSingleUserData(string name)
    {
        var exist = userDatas.Find((x) => x.Name == name);
        if (exist != null)
        {
            userDatas.Remove(exist);
            return true;
        }
        else
            return false;
    }

    public void UpdateSingleUserData(UserData data)
    {
        var exist = userDatas.Find((x) => x.Name == data.Name && x.Alias != data.Alias);
        if (exist != null)
        {
            userDatas.Remove(exist);
            userDatas.Add(data);
        }
    }

    public void AddSingleUserData(UserData data) => userDatas.Add(data);

    public void AddMultipleUserData(List<UserData> data)
    {
        foreach (var item in data)
        {
            AddSingleUserData(item);
        }
    }

    public void DeleteSingleUserDataById(int id) => userDatas.Remove(userDatas.Find((x) => x.UserDataId == id));

    public void DeleteSingleUserDataByName(string name)
    {
        throw new NotImplementedException();
    }

    public void UpdateTimePlayedByName(string data)
    {
        throw new NotImplementedException();
    }
}
