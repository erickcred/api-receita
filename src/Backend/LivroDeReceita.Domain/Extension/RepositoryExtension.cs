using Microsoft.Extensions.Configuration;

namespace LivroDeReceita.Domain.Extension;

public static class RepositoryExtension
{
  public static string GetDatabaseName(this IConfiguration configuration)
  {
    var databaseName = configuration.GetConnectionString("DatabaseName");
    return databaseName;
  }

  public static string GetConnection(this IConfiguration configuration)
  {
    var connection = configuration.GetConnectionString("Connection");
    return connection;
  }

  public static string GetFullConnectionString(this IConfiguration configuration)
  {
    var databaseName = configuration.GetDatabaseName();
    var connection = configuration.GetConnection();
    return $"{connection}Database={databaseName}";
  }
}
