using Dapper;
using MySqlConnector;

namespace LivroDeReceita.Infrastructure.Migrations;

public static class Database
{
  public static void CreateConnection(string connectionString, string databaseName)
  {
    using var connection = new MySqlConnection(connectionString);

    var param = new DynamicParameters();
    param.Add("name", databaseName);

    var result = connection.Query("SELECT * FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = @name", param);

    if (!result.Any())
    {
      connection.Execute($"CREATE DATABASE { databaseName }");
    }
  }
}
