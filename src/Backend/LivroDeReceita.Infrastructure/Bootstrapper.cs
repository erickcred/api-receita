using FluentMigrator.Runner;
using LivroDeReceita.Domain.Extension;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace LivroDeReceita.Infrastructure;

public static class Bootstrapper
{
  public static void AddReposiroty(this IServiceCollection services, IConfiguration configuration)
  {
    AddFluentMigratior(services, configuration);
  }

  private static void AddFluentMigratior(IServiceCollection services, IConfiguration configuration)
  {
    services.AddFluentMigratorCore().ConfigureRunner(c => 
      c.AddMySql5()
      .WithGlobalConnectionString(configuration.GetFullConnectionString())
      .ScanIn(Assembly.Load("LivroDeReceita.Infrastructure")).For.All()
    );
  }
}
