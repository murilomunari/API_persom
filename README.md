Project APIPerson.

Tecnologias Utilizadas
C#
.NET 8
Entity Framework Core
SQLite
Migrations com EF Core
Configuração do Ambiente

Pré-requisitos
.NET SDK instalado na máquina. Baixe no site oficial da Microsoft.
Editor de código, como o Visual Studio, Rider ou VS Code.
Opcional: Ferramentas para gerenciar SQLite, como DB Browser for SQLite.
Como Configurar o Projeto
1. Clone o Repositório
bash
Copiar código
git clone https:https://github.com/murilomunari/API_person.git
cd seu-repositorio
2. Restaure os Pacotes
Use o comando abaixo para restaurar as dependências do projeto:

dotnet restore
3. Execute as Migrações
Crie e aplique as migrações para configurar o banco de dados SQLite:

dotnet ef migrations add InitialCreate
dotnet ef database update
4. Execute o Projeto
Inicie o servidor de desenvolvimento:

dotnet run
A API estará disponível em: http://localhost:7252.

Recursos da API
Endpoints
1. Listar Todos os Recursos
GET /api/person
Retorna uma lista de todos os recursos.

2. Obter Recurso por NOME
GET /api/person/{Nome}
Retorna um recurso específico com base no Nome.

3. Criar um Novo Recurso
POST /api/person
Corpo da Requisição (JSON):

{
  "name": "Exemplo",
  "description": "Descrição do recurso"
}
4. Atualizar um Recurso
PUT /api/person/{Id}
Corpo da Requisição (JSON):

{
  "name": "Novo Nome",
  "description": "Nova descrição"
}
5. Excluir um Recurso
DELETE /api/resource/{Nome}
Remove o recurso especificado pelo Nome.


Banco de Dados
SQLite é utilizado como banco de dados. O arquivo do banco será criado automaticamente no diretório do projeto após a execução da aplicação.
Exemplo de Configuração do EF Core
No arquivo AppDbContext.cs:

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Resource> Resources { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db");
}
Comandos Úteis
Adicionar Migração

dotnet ef migrations add NomeDaMigracao
Atualizar Banco de Dados

dotnet ef database update
Remover Migração

dotnet ef migrations remove
