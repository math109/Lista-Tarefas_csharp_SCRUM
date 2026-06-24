using System;
using MongoDB.Driver; // Importa o driver do MongoDB

class Program
{
    static void Main()
    {
        string minhaConexao = Environment.GetEnvironmentVariable("MONGODB_URI")
            ?? "mongodb+srv://<seu_username>:<sua_senha>@matheusdb.qmczipp.mongodb.net/?appName=matheusdb";

        var settings = MongoClientSettings.FromConnectionString(minhaConexao);
        var cliente = new MongoClient(settings);

        try
        {
            cliente.ListDatabaseNames();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar ao MongoDB:");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Verifique a string de conexão, as credenciais e se seu IP está liberado no Atlas.");
            return;
        }

        var banco = cliente.GetDatabase("GerenciadorTarefas");
        var colecao = banco.GetCollection<Tarefa>("Tarefas");

        bool rodando = true;

        while (rodando)
        {
            Console.WriteLine("=== Lista de Tarefas (MongoDB) ===");
            Console.WriteLine("1. Adicionar Tarefa");
            Console.WriteLine("2. Listar Tarefas");
            Console.WriteLine("3. Atualizar Tarefa");
            Console.WriteLine("4. Deletar Tarefa");
            Console.WriteLine("5. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine() ?? "";

            if (opcao == "1")
            {
                Console.Write("Digite o nome da tarefa: ");
                string nomeDigitado = Console.ReadLine() ?? "";

                var novaTarefa = new Tarefa { Nome = nomeDigitado };
                colecao.InsertOne(novaTarefa); 
                Console.WriteLine("Tarefa salva no MongoDB!\n");
            }
            else if (opcao == "2")
            {
                Console.WriteLine("\n--- Suas Tarefas ---");
                var todasAsTarefas = colecao.Find(t => true).ToList();

                foreach (var t in todasAsTarefas)
                {
                    Console.WriteLine($"ID: {t.Id} | Tarefa: {t.Nome}");
                }
                Console.WriteLine("--------------------\n");
            }
            else if (opcao == "3")
            {
                Console.Write("Digite o ID da tarefa que deseja alterar: ");
                string idParaEditar = Console.ReadLine() ?? "";

                Console.Write("Digite o NOVO nome para esta tarefa: ");
                string novoNome = Console.ReadLine() ?? "";

                var filtro = Builders<Tarefa>.Filter.Eq(t => t.Id, idParaEditar);
                var alteracao = Builders<Tarefa>.Update.Set(t => t.Nome, novoNome);
                var resultado = colecao.UpdateOne(filtro, alteracao);

                if (resultado.ModifiedCount > 0)
                {
                    Console.WriteLine("Tarefa atualizada com sucesso!\n");
                }
                else
                {
                    Console.WriteLine("Nenhuma tarefa foi alterada. Verifique o ID.\n");
                }
            }
            else if (opcao == "4")
            {
                Console.Write("Digite o ID da tarefa que deseja apagar: ");
                string idParaApagar = Console.ReadLine() ?? "";

                var filtro = Builders<Tarefa>.Filter.Eq(t => t.Id, idParaApagar);
                var resultado = colecao.DeleteOne(filtro);

                if (resultado.DeletedCount > 0)
                {
                    Console.WriteLine("Tarefa removida com sucesso!\n");
                }
                else
                {
                    Console.WriteLine("Tarefa não encontrada.\n");
                }
            }
            else if (opcao == "5")
            {
                rodando = false;
            }
            else
            {
                Console.WriteLine("Opção inválida!\n");
            }
        }
    }
}