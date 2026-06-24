```markdown
Gerenciador de Tarefas (CRUD) com .NET 10 e MongoDB Atlas

Este é um projeto prático de um **Gerenciador de Tarefas em Console** desenvolvido em C# utilizando o **.NET 10**. O sistema foi originalmente projetado utilizando SQLite com Entity Framework Core e, posteriormente, migrado com sucesso para o **MongoDB Atlas**, um banco de dados NoSQL totalmente baseado na nuvem.

O projeto implementa todas as operações essenciais de um sistema de persistência de dados (**CRUD**): Criação, Leitura, Atualização e Deleção de registros.

 Funcionalidades

- Adicionar Tarefa (Create):** Instancia um novo objeto tarefa e o envia em formato JSON diretamente para a nuvem.
- Listar Tarefas (Read):** Recupera todos os documentos armazenados na coleção do MongoDB e os exibe de forma legível no console.
- Atualizar Tarefa (Update):** Permite alterar o status (Concluída/Pendente) de uma tarefa existente através do seu identificador único.
- Deletar Tarefa (Delete):** Remove permanentemente um documento de tarefa do banco de dados na nuvem.

---

 Tecnologias Utilizadas

- Linguagem: C#
- Plataforma: .NET 10.0 (Versão mais recente do ecossistema)
- Banco de Dados: MongoDB Atlas (Nuvem / NoSQL orientado a documentos)
- Driver de Conexão: `MongoDB.Driver` (v2.20.0)
- Editor de Código: Visual Studio Code

 Estrutura do Projeto Explicada

O ecossistema do projeto está dividido em componentes claros e interconectados:

1. Program.cs: Contém o fluxo principal de execução, o loop dinâmico do menu interativo e as chamadas de API do driver do MongoDB (`InsertOne`, `Find`, etc.). Também traz uma implementação customizada via `SslSettings` para contornar bloqueios de TLS/Schannel nativos do Windows (Erro `0x80090304`).
2. Tarefa.cs: Classe de entidade que molda a estrutura dos dados. Define os campos estruturais: `Id` (mapeado como `ObjectId` automático do Mongo), `Nome` (string) e `Concluida` (boolean).
3. ListaTarefas.cspro: Arquivo XML que gerencia as propriedades de compilação do projeto e centraliza as dependências externas do NuGet necessárias para a tradução do código.

 Como Executar o Projeto Localmente

 Pré-requisitos
- Ter o SDK do .NET 10 instalado na máquina.
- Uma conta ativa com uma Connection String válida do MongoDB Atlas

Passo a Passo

1. Clonar o Repositório:
   ```bash
   git clone [https://github.com/SEU_USUARIO/ListaTarefas-MongoDB.git](https://github.com/SEU_USUARIO/ListaTarefas-MongoDB.git)
   cd ListaTarefas-MongoDB
