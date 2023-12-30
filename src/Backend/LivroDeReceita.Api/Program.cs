using LivroDeReceita.Domain.Extension;
using LivroDeReceita.Infrastructure;
using LivroDeReceita.Infrastructure.Migrations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddReposiroty(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

UpdataDatabase();

app.Run();

void UpdataDatabase()
{
  var connection = RepositoryExtension.GetConnection(builder.Configuration);
  var databaseName = RepositoryExtension.GetDatabaseName(builder.Configuration);
  Database.CreateConnection(connection, databaseName);

  app.MigrateDatabase();
}
