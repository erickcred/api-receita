using FluentMigrator.Runner;
using LivroDeReceita.Domain.Extension;
using LivroDeReceita.Domain.Repositories.Interfaces;
using LivroDeReceita.Infrastructure.AccessRepositories;
using LivroDeReceita.Infrastructure.AccessRepositories.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceita.Infrastructure;

public static class Bootstrapper
{
  public static void AddReposiroty(this IServiceCollection services, IConfiguration configuration)
  {
    AddFluentMigratior(services, configuration);

    AddContext(services, configuration);
    AddCommit(services);
    AddRepositories(services);
  }

  private static void AddContext(IServiceCollection services, IConfiguration configuration)
  {
    services.AddDbContext<LivroDeReceitaContext>(options =>
    {
      string connectionString = ConfigurationExtension.GetFullConnectionString(configuration);
      options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });
  }

  private static void AddCommit(IServiceCollection services)
  {
    services.AddScoped<IUnityOfWork, UnityOfWork>();
  }

  private static void AddRepositories(IServiceCollection services)
  {
    services.AddScoped<IUsuarioRepository, UsuarioRepository>();
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
