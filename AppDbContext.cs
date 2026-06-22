using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    // Diz que queremos uma tabela chamada "Tarefas" baseada na classe Tarefa
    public DbSet<Tarefa> Tarefas { get; set; }

    // Configura o EF Core para usar o SQLite e criar um arquivo chamado 'banco.db'
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=banco.db");
    }
}