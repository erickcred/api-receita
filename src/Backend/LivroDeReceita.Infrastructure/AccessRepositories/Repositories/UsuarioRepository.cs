using LivroDeReceita.Domain.Entities;
using LivroDeReceita.Domain.Repositories.Interfaces;
using LivroDeReceita.Infrastructure.AccessRepositories;
using Microsoft.EntityFrameworkCore;

namespace LivroDeReceita.Infrastructure.AccessRepositories.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
  private readonly LivroDeReceitaContext _context;

  public UsuarioRepository(LivroDeReceitaContext context)
  {
    _context = context;
  }

  public async Task Add(Usuario usuario)
  {
    if (usuario != null)
      await _context.Usuarios.AddAsync(usuario);
  }

  public async Task<bool> UserEmailExists(string email)
  {
    return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
  }
}
