namespace LivroDeReceita.Domain.Entities;

public class Usuario : BaseEntity
{
  public string Email { get; set; }
  public string Telefone { get; set; }
  public string Senha { get; set; }
  public DateTime DataCadastro { get; set; }

  public Usuario() { }
  public Usuario(
    long id,
    string nome,
    string email,
    string telefone,
    string senha,
    DateTime dataCadastro) : base(id, nome)
  {
    Email = email;
    Telefone = telefone;
    Senha = senha;
    DataCadastro = dataCadastro;
  }
}
