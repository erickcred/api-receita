using LivroDeReceita.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceita.Infrastructure.AccessRepositories;

public class LivroDeReceitaContext : DbContext
{
  public LivroDeReceitaContext(DbContextOptions<LivroDeReceitaContext> options) : base(options) { }

  public DbSet<Usuario> Usuarios { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfigurationsFromAssembly(typeof(LivroDeReceitaContext).Assembly);
  }
}
