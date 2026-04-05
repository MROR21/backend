# 🛡️ Desafio Root - API (Backend)

Esta é a API RESTful desenvolvida em **.NET 8** para o gerenciamento de tarefas do sistema Desafio Root.

### 🛠️ Tecnologias Utilizadas
* **Linguagem:** C#
* **Framework:** ASP.NET Core Web API (.NET 8)
* **ORM:** Entity Framework Core (Code First)
* **Banco de Dados:** PostgreSQL
* **Documentação:** Swagger (OpenAPI)

### 🚀 Como Rodar o Projeto
1. **Configuração do Banco:** Verifique a `ConnectionString` no `appsettings.json`.
2. **Execução de Migrations e Start:**
   ```bash
   # Criar as tabelas no banco de dados
   dotnet ef database update

   # Iniciar o servidor da API
   dotnet run

    Domain/          # Entidades e Regras de Negócio
    Application/     # Interfaces e DTOs
    Infrastructure/  # DbContext, Migrations e Repositórios
    Controllers/     # Endpoints da API 