namespace TestApi;

public class UserData
{
    //public int Id { get; set; }
    public int UserDataId { get; set; }
    public string? Name { get; set; }
    public string? Alias { get; set; }
    public GameData? GameData { get; set; }
}
