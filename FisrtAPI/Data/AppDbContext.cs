using FisrtAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FisrtAPI.Data;

//Contexto de dado da nossa aplicação - representação do nosso banco em memoria
public class AppDbContext : DbContext
{
    //Represatação de uma tabela em memoria , reprenseta nossa tarefa
    public DbSet<Todo> Todos { get; set; }

    //Conexão
    protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("DataSource=app.db;Cache=Shared");
}

/* Ordem de comando
  
    core.sqlite
    core.design
    core.tools
    dotnet tool install --global dotnet-ef
                update --global dotnet-ef
    dotnet ef(testar)

  -dotnet clean
 - dotnet build
 - dotnet ef migrations add (name) Start:InitialCreation
 - dotnet ef database update
 */

