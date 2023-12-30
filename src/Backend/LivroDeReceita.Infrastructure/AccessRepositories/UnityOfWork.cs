using LivroDeReceita.Domain.Repositories.Interfaces;

namespace LivroDeReceita.Infrastructure.AccessRepositories;

public sealed class UnityOfWork : IDisposable, IUnityOfWork
{
  private readonly LivroDeReceitaContext _context;
  private bool _disposed;

  public UnityOfWork(LivroDeReceitaContext context)
  {
    _context = context;
  }

  public async Task Commit()
  {
    await _context.SaveChangesAsync();
  }

  public void Dispose()
  {
    Dispose(true);
  }

  private void Dispose(bool dispose)
  {
    if (!_disposed && dispose)
    {
      _context.Dispose();
    }

    _disposed = true;
  }
}
