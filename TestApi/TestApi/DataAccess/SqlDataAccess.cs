using Dapper;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TestApi.DataAccess;

public class SqlDataAccess
{
    private readonly IConfiguration _config;

    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public List<UserData> GetUserData(string command)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("TestDB")))
        {
            List<UserData> data = new();

            conn.Open();

            SqlCommand cmd = new(command, conn);

            Console.WriteLine(command);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                data.Add(new UserData { UserDataId = reader.GetInt32(0), Name = reader.GetString(1), Alias = reader.GetString(2), GameData = new() { GameDataId = reader.GetInt32(3), UserDataId = reader.GetInt32(4), HighScore = reader.GetInt32(5), LevelsCompleted = reader.GetInt32(6), TimePlayed = reader.GetDouble(7) } });
            }

            reader.Close();
            conn.Close();
           
            return data;
        }
    }

    public void DeleteUserData(string command)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("TestDB")))
        {
            conn.Open();

            SqlCommand cmd = new(command, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }

    public void InsertIntoUserData(string userData)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("TestDB")))
        {
            conn.Open();
            
            SqlCommand cmd = new(userData, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }

    internal void UpdataData(string command)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("TestDB")))
        {
            conn.Open();

            SqlCommand cmd = new(command, conn);
            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }
}