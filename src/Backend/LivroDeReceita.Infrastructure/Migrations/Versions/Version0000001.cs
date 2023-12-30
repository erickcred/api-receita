using FluentMigrator;
using LivroDeReceita.Infrastructure.Migrations.Enums;

namespace LivroDeReceita.Infrastructure.Migrations.Versions;

[Migration((long)EMigrationVersions.CriarTabelaUsuario, "Cria tabela usuario")]
public class Version0000001 : Migration
{
  public override void Down()
  {
    var table = Delete.Table("Usuario");
  }

  public override void Up()
  {
    var table = Create.Table("Usuario");

    BaseVersion.InsertColumnTableDefault(table)
      .WithColumn("Nome").AsString(100).NotNullable()
      .WithColumn("Email").AsString(100).NotNullable()
      .WithColumn("Telefone").AsString(16).NotNullable()
      .WithColumn("Senha").AsString(2000).NotNullable();

  }
}
