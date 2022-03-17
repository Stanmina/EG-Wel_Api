namespace TestApi
{
    public class UserData
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Alias { get; set; }
        //public string FistTimePlayed { get; set; } = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
        public GameData? GameData { get; set; }
    }
}
