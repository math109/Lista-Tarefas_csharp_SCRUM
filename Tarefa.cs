public class Tarefa
{
    public int Id { get; set; } // O EF Core entende que isso será a Chave Primária automática
    public string Nome { get; set; } = string.Empty;
}