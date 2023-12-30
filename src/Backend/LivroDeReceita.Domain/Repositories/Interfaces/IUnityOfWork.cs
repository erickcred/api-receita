namespace LivroDeReceita.Domain.Repositories.Interfaces;

public interface IUnityOfWork
{
  Task Commit();
}
