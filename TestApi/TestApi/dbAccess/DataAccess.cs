using System.Data.SQLite;

namespace TestApi;
public class DataAccess
{
    SQLiteConnection conn = new(@"Data Source=C:\Users\EG-Wel\Documents\GitHub\EG-Wel_Api\TestApi\TestApi\testdb.db");
    public List<UserData> GetUserData(string command)
    {
        List<UserData> data = new();

        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = command;

        SQLiteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            data.Add(new UserData { UserDataId = reader.GetInt32(0), Name = reader.GetString(1), Alias = reader.GetString(2), GameData = new() { Id = reader.GetInt32(3), HighScore = reader.GetInt32(4), LevelsCompleted = reader.GetInt32(5), TimePlayed = reader.GetInt32(6) } });
        }
        reader.Close();
        conn.Close();
        
        return data;
    }

    public void PostSingleUserData(UserData data)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"INSERT INTO UserData ( Name, Alias ) VALUES ('{data.Name}', '{data.Alias}');" +
            $"INSERT INTO GameData ( HighScore, LevelsCompleted, TimePlayed ) VALUES ( {data.GameData.HighScore}, {data.GameData.LevelsCompleted}, {data.GameData.TimePlayed} );";
        cmd.ExecuteNonQuery();

        conn.Close();
    }
    public void PostMultipleUserData(List<UserData> userDatas)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);

        string userDataQuerryBuilder = $"INSERT INTO UserData ( Name, Alias ) VALUES";
        string gameDataQuerryBuilder = $"INSERT INTO GameData ( HighScore, LevelsCompleted, TimePlayed ) VALUES";

        for (int i = 0; i < userDatas.Count; i++)
        {
            userDataQuerryBuilder += $"('{ userDatas[i].Name }', '{ userDatas[i].Alias }')";
            gameDataQuerryBuilder += $"('{ userDatas[i].GameData.HighScore }', '{ userDatas[i].GameData.LevelsCompleted }', '{ userDatas[i].GameData.TimePlayed }')";
            
            if (i != userDatas.Count - 1)
            {
                userDataQuerryBuilder += ", ";
                gameDataQuerryBuilder += ", ";
            }
        } 


        cmd.CommandText = userDataQuerryBuilder + ";" + gameDataQuerryBuilder;
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public void DeleteUserData(int id)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"DELETE FROM UserData WHERE UserDataId = {id};" +
            $"DELETE FROM GameData WHERE UserDataId = {id};";
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public void PutGameData(UserData data)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"UPDATE UserData SET UserDataId = {data.UserDataId}, Name = '{data.Name}', Alias = '{data.Alias}' WHERE UserDataId = {data.UserDataId};" +
            $"UPDATE GameData SET  HighScore = {data.GameData.HighScore}, LevelsCompleted = {data.GameData.LevelsCompleted}, TimePlayed = {data.GameData.TimePlayed} WHERE UserDataId = {data.UserDataId};";
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public List<UserData> GetHighScoreList(string command)
    {
        List<UserData> data = new();

        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = command;

        SQLiteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            data.Add( new UserData { UserDataId = reader.GetInt32(0), Name = reader.GetString(1), Alias = reader.GetString(2), GameData = new() { Id = reader.GetInt32(3), HighScore = reader.GetInt32(4), LevelsCompleted = reader.GetInt32(5), TimePlayed = reader.GetInt32(6) }});
        }
        reader.Close();

        conn.Close();

        return data;
    }
}