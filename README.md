#  CP4 .NET - Biblioteca de Livros

Projeto desenvolvido como parte do **Checkpoint 4**, utilizando **ASP.NET Core 8.0** integrado com **MongoDB Atlas**.

##  Tecnologias Utilizadas
- ASP.NET Core 8.0 (MVC + Web API)
- MongoDB Atlas (banco de dados na nuvem)
- Swagger (documentação e testes da API)
- Bootstrap (Views do MVC)
- C# 12

##  Estrutura do Projeto
- **Models** → contém as classes `Livro` e `Autor`
- **Data** → contém a configuração `MongoDbSettings`
- **Service** → contém o `LivroService`, responsável pelo CRUD no MongoDB
- **Controllers**
  - `LivroController` (MVC com Views)
  - `LivrosController` (API REST, usado no Swagger)
- **Views/Livro** → telas de listagem, criação, edição e exclusão

## Configuração do Banco de Dados
No arquivo `appsettings.json`, configure a string de conexão do Atlas:

```json
{
  "MongoDb": {
    "ConnectionString": "mongodb+srv://<usuario>:<senha>@<cluster>.mongodb.net/?retryWrites=true&w=majority&appName=Cp",
    "DatabaseName": "Cp",
    "LivroCollectionName": "Livros"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

> Substitua `<usuario>` e `<senha>` pelas credenciais criadas no Atlas. Se a senha tiver caracteres especiais, use **URL encode** (ex.: `@` → `%40`).

## ▶️ Como Rodar o Projeto

1. **Clonar o repositório**
   ```bash
   git clone <url-do-repo>
   cd cp4-dotnet
   ```

2. **Restaurar pacotes**
   ```bash
   dotnet restore
   ```

3. **Compilar**
   ```bash
   dotnet build
   ```

4. **Rodar a aplicação**
   ```bash
   dotnet run
   ```

5. **Acessar no navegador**
   - Swagger (API): [http://localhost:5222/swagger](http://localhost:5222/swagger)

##  Exemplos de Uso

### Criar Livro (POST /api/Livros)
```json
{
  "titulo": "Crônicas da Nova República",
  "anoPublicacao": 2025,
  "autor": {
    "nome": "Juliana Santos",
    "nacionalidade": "Brasileira"
  }
}
```

### Resposta esperada
```json
{
  "id": "6502a1f4c43f3456789abcde",
  "titulo": "Crônicas da Nova República",
  "anoPublicacao": 2025,
  "autor": {
    "nome": "Juliana Santos",
    "nacionalidade": "Brasileira"
  }
}
```

##  Funcionalidades
- Listar todos os livros (MVC e API)
- Detalhar livro específico
- Criar novo livro
- Editar livro existente
- Excluir livro
- Autor embutido (embedding) dentro do documento Livro

##  Autores
- Raphaela Oliveira Tatto - RM554983  
- Tiago Ribeiro Capela - RM558021
