using TestApi.Models;

namespace TestApi.Interfaces;

public interface IScoreService
{
    public List<Time> GetAllByLevel(string levelName);
    public List<User> GetAllUsers();
    public void InsertNewUser(User user);
    public void PutTime(UpdateTime data);
    public void InsertNewTime(string name, string level, string time);
    public List<Level> GetAllLevelsByUser(string name);
    public bool GetUser(string name, string password);
}
