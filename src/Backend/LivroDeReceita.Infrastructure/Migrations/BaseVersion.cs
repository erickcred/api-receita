using FluentMigrator.Builders.Create.Table;

namespace LivroDeReceita.Infrastructure.Migrations;

public static class BaseVersion
{
  public static ICreateTableWithColumnOrSchemaOrDescriptionSyntax InsertColumnTableDefault(ICreateTableWithColumnOrSchemaOrDescriptionSyntax table)
  {

    table.WithColumn("Id").AsInt64().PrimaryKey().Identity()
      .WithColumn("DataCadastro").AsDateTime().NotNullable();

    return table;
  }
}
