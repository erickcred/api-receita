using LivroDeReceita.Domain.Entities;

namespace LivroDeReceita.Domain.Repositories.Interfaces;

public interface IUsuarioRepository
{
  Task Add(Usuario usuario);
  Task<bool> UserEmailExists(string email);
}
