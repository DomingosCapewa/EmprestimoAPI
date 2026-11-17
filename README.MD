# Emprestimo API

API REST para gerenciamento de empréstimos, com operações de criação, consulta, atualização e exclusão.

## Stack

- .NET 9;
- ASP.NET Core Web API;
- Entity Framework Core;
- MySQL;
- Swagger/OpenAPI.

## Requisitos

- .NET SDK 9.0;
- MySQL em execução;
- Uma connection string configurada em `appsettings.json` ou `appsettings.Development.json`.

## Configuração

Defina a conexão com o banco usando a chave `DefaultConnection`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=emprestimo;user=root;password=sua_senha"
  }
}
```

Não versione senhas ou outras credenciais reais. Para desenvolvimento local, use `appsettings.Development.json` ou variáveis de ambiente.

## Executando

Na raiz do projeto:

```bash
dotnet restore
dotnet run
```

Durante o desenvolvimento, a documentação Swagger fica disponível em:

```text
https://localhost:<porta>/swagger
```

O endereço exato pode ser consultado em `Properties/launchSettings.json`.

## Endpoints

Os endpoints de empréstimos estão disponíveis nos controllers do projeto. Consulte o Swagger para visualizar os modelos, parâmetros e exemplos atualizados da API.

## Estrutura

```text
├── src/
├── Program.cs
├── EmprestimoApi.csproj
└── Properties/
```
