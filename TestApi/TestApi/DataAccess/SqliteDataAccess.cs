using System.Data.SQLite;

namespace TestApi;
public class SqliteDataAccess
{
    SQLiteConnection conn = new(@"Data Source=testdb.db");
    public List<UserData> GetUserData(string command)
    {
        List<UserData> data = new();

        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = command;

        SQLiteDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            data.Add(new UserData { UserDataId = reader.GetInt32(0), Name = reader.GetString(1), Alias = reader.GetString(2), GameData = new() { GameDataId = reader.GetInt32(3), HighScore = reader.GetInt32(4), LevelsCompleted = reader.GetInt32(5), TimePlayed = reader.GetDouble(6) } });
        }
        reader.Close();
        conn.Close();

        return data;
    }

    public void PostSingleUserData(UserData data)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"INSERT INTO UserData ( Name, Alias ) VALUES ('{data.Name}', '{data.Alias}')";
        cmd.ExecuteNonQuery();

        conn.Close();
    }
    public void PostMultipleUserData(List<UserData> userDatas)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);

        string querryBuilder = $"INSERT INTO UserData ( Name, Alias ) VALUES";

        for (int i = 0; i < userDatas.Count; i++)
        {
            querryBuilder += $"('{ userDatas[i].Name }', '{ userDatas[i].Alias }')";
            if (i != userDatas.Count - 1)
                querryBuilder += ", ";
        }
        cmd.CommandText = querryBuilder;
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public void DeleteUserData(int id)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"DELETE FROM UserData WHERE Id = {id}";
        cmd.ExecuteNonQuery();

        conn.Close();
    }

    public void PutGameData(UserData data)
    {
        conn.Open();

        SQLiteCommand cmd = new(conn);
        cmd.CommandText = $"UPDATE UserData SET Name = '{data.Name}', Alias = '{data.Alias}' WHERE Id = {data.UserDataId}";
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
            data.Add(new UserData { UserDataId = reader.GetInt32(0), Name = reader.GetString(1), Alias = reader.GetString(2), GameData = new() { GameDataId = reader.GetInt32(3), HighScore = reader.GetInt32(4), LevelsCompleted = reader.GetInt32(5), TimePlayed = reader.GetDouble(6) } });
        }
        reader.Close();

        conn.Close();

        return data;
    }
}