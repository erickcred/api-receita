namespace LivroDeReceita.Domain.Entities;

public abstract class BaseEntity
{
  public long Id { get; set; }
  public string Nome { get; set; }

  public BaseEntity() { }
  public BaseEntity(long id, string nome)
  {
    Id = id;
    Nome = nome;
  }
}
