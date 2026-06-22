using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        using var db = new AppDbContext();
        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("=== Minha Lista de Tarefas ===");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Apagar Tarefa");
            Console.WriteLine("4. Sair");
            Console.Write("O que você quer fazer? ");

            string opcao = Console.ReadLine();
            if (opcao == "1") 
            {
                string nomeDigitado = Console.ReadLine() ?? "";
                var novaTarefa = new Tarefa { Nome = nomeDigitado };
                db.Tarefas.Add(novaTarefa);
                db.SaveChanges();
            }
            else if (opcao == "2") 
            {
                Console.WriteLine("\n--- Suas Tarefas ---");
                foreach (var tarefa in db.Tarefas) 
                {
                    Console.WriteLine("- " + tarefa.Nome);
                }
                Console.WriteLine("--------------------\n");
            }
            else if (opcao == "3")
            {
                for (int i = 0; i < db.Tarefas.Count(); i++)
                {
                    Console.WriteLine(i + " - " + db.Tarefas.ElementAt(i).Nome);
                }
                Console.Write("Digite o número da tarefa que deseja apagar: ");
                string idTexto = Console.ReadLine();
                int idDigitado = int.Parse(idTexto);
                var tarefaParaRemover = db.Tarefas.Find(idDigitado);
                if (tarefaParaRemover != null)
                {
                    db.Tarefas.Remove(tarefaParaRemover);
                    db.SaveChanges();
                }
                Console.WriteLine("Tarefa removida com sucesso!");
            }

            else if (opcao == "4") 
            {
                rodando = false;
            }
            else 
            {
                Console.WriteLine("Opção inválida, tente de novo!\n");
            }
        }
    }
}
