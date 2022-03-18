namespace TestApi;
public interface IHighScoreService
{
    public List<UserData> GetUserDatas();
    public List<UserData> GetHighScoreList();
    public UserData? GetSingleUserData(string name);
    public UserData? GetSingleUserDataByAlias(string alias);
    public List<UserData> GetHighscoreUserData(int highScore);
    public List<UserData> GetLevelCompletedUserData(int levelCompleted);
    public double GetAverageHighScore();
    public bool DeleteSingleUserData(string name);
    public void UpdateSingleUserData(UserData data);
    public void AddSingleUserData(UserData data);
    public void AddMultipleUserData(List<UserData> data); 
    public void DeleteSingleUserDataById(int id);
}