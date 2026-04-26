# GoodHamburguer API 🍔

API para gerenciamento de pedidos de uma hamburgueria, desenvolvida com foco em Clean Architecture, Domain-Driven Design (DDD) e alta testabilidade.

## 🚀 Tecnologias Utilizadas

- **.NET 10**
- **Entity Framework Core 9**
- **MySQL** (Pomelo Entity Framework Core MySql)
- **Swagger / OpenAPI** para documentação
- **xUnit** para testes unitários
- **Moq** para simulação de dependências
- **Bogus** para geração de dados aleatórios (Data Generation)
- **FluentAssertions** para validações de testes legíveis

## 🏛️ Arquitetura e Decisões

O projeto segue os princípios da **Clean Architecture**, garantindo desacoplamento e facilidade de manutenção:

1.  **Domain**: O coração da aplicação. Contém as entidades (`Order`, `Product`), Enums e interfaces de repositório.
2.  **Application**: Implementa a lógica de negócio através de **Use Cases**. Orquestra a persistência e validações.
3.  **Infrastructure**: Implementa o acesso a dados, configurações do EF Core (Fluent API) e o padrão **Unit of Work**.
4.  **Communication**: Contratos de entrada e saída (DTOs) da API.
5.  **SharedKernel**: Recursos compartilhados como exceções personalizadas e helpers.
6.  **CommonTestUtilities**: Projeto auxiliar com **Builders** fluentes e utilitários para facilitar a criação de testes.
7.  **Tests (UseCases.Tests)**: Cobertura de testes unitários para toda a lógica de negócio dos pedidos.

### Decisões Técnicas:
- **Migrations Automáticas**: O banco de dados é criado e atualizado automaticamente ao iniciar a API, eliminando a necessidade de comandos manuais no primeiro uso.
- **Data Seeding**: Produtos iniciais (X Burger, Batata, etc.) são inseridos automaticamente via Migration.
- **Fluent Builders**: Implementação de Builders com **Bogus** para garantir que os testes sejam resilientes a mudanças nas entidades.
- **Middleware de Exceção**: Tratamento global que converte exceções de negócio (`NotFound`, `BadRequest`) em status codes HTTP apropriados.

## 🛠️ Como Executar

### Pré-requisitos
- .NET 10 SDK
- Servidor MySQL

### Configuração
1.  No arquivo `src/GoodHamburguer.API/appsettings.json`, ajuste a connection string `Default`:
    ```json
    "ConnectionStrings": {
      "Default": "server=localhost;database=goodhamburguer;user=root;password=SUA_SENHA"
    }
    ```

### Execução da API
1.  Navegue até a raiz do projeto.
2.  Execute:
    ```bash
    dotnet run --project src/GoodHamburguer.API
    ```
    *O banco será criado e populado automaticamente no primeiro acesso.*

### Execução dos Testes
1.  Para rodar todos os testes unitários:
    ```bash
    dotnet test
    ```

## 📝 O que ficou de fora (Próximos Passos)

- **Dockerização**: Containerização da API e do MySQL via `docker-compose`.
- **Autenticação**: Proteção dos endpoints com JWT.
- **Testes de Integração**: Testes que validam a persistência real no banco de dados.
- **Logging Estruturado**: Implementação de Serilog para rastreabilidade em produção.

---
Desenvolvido com foco em qualidade de código e padrões modernos de desenvolvimento .NET.
