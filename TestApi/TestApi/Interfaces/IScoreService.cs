using TestApi.Models;

namespace TestApi.Interfaces;

public interface IScoreService
{
    public List<Time> GetAllByLevel(string levelName);

    public List<User> GetAllUsers();
}
