﻿using Dapper;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using TestApi.Models;

namespace TestApi.NewDataAccess;

public class NewSqlDataAccess
{
    private readonly IConfiguration _config;

    public NewSqlDataAccess(IConfiguration config) => _config = config;

    public List<Time> GetUserData(string command)
    {
        using (SqlConnection conn = new SqlConnection(_config.GetConnectionString("EG-Wel")))
        {
            List<Time> data = new();

            Console.WriteLine(command);

            conn.Open();

            SqlCommand cmd = new(command, conn);

            SqlDataReader reader = cmd.ExecuteReader();

            Console.WriteLine(reader);

            while (reader.Read())
            {
                data.Add(new Time() { name = reader.GetString(0), alias = reader.GetString(1), time = reader.GetDouble(2) });
            }

            reader.Close();
            conn.Close();

            return data;
        }
    }
}