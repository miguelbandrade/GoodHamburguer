# GoodHamburguer API 🍔

API para gerenciamento de pedidos de uma hamburgueria, desenvolvida com foco em Clean Architecture e boas práticas de desenvolvimento .NET.

## 🚀 Tecnologias Utilizadas

- **.NET 10**
- **Entity Framework Core 9**
- **MySQL** (Pomelo Entity Framework Core MySql)
- **Swagger / OpenAPI** para documentação

## 🏛️ Arquitetura e Decisões

O projeto foi estruturado seguindo os princípios da **Clean Architecture**, dividido nas seguintes camadas:

1.  **Domain**: Contém as entidades de negócio (`Order`, `Product`, `OrderProduct`), interfaces de repositório e o padrão Unit of Work. É a camada central e não possui dependências externas.
2.  **Application**: Implementa os casos de uso (`UseCases`) da aplicação. Aqui reside a lógica de negócio, orquestrando a comunicação entre o domínio e a infraestrutura.
3.  **Infrastructure**: Responsável pelo acesso a dados, configuração do Entity Framework Core, migrações e implementação dos repositórios.
4.  **Communication**: Define os contratos de entrada (`Requests`) e saída (`Responses`) da API, garantindo o desacoplamento das entidades de domínio.
5.  **SharedKernel**: Contém recursos compartilhados por todas as camadas, como Enums e Exceções personalizadas.
6.  **API**: Ponto de entrada da aplicação, contendo os Controllers e Middlewares.

## 🛠️ Como Executar

### Pré-requisitos
- .NET 10 SDK
- Servidor MySQL

### Configuração
1.  Clone o repositório.
2.  Crie um arquivo `src/GoodHamburguer.API/appsettings.json` e ajuste a connection string `Default` com suas credenciais do MySQL:
    ```json
    {
        "Logging": {
            "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
            }
        },
        "AllowedHosts": "*",
        "ConnectionStrings": {
            "Default": "Sua Connection String"
        }
    }
    ```

### Execução via CLI
1.  Navegue até a raiz do projeto.
2.  Restaure as dependências:
    ```bash
    dotnet restore
    ```
3.  Execute a aplicação:
    ```bash
    dotnet run --project src/GoodHamburguer.API
    ```
4.  Acesse o Swagger em: `https://localhost:7025/swagger` (ou a porta indicada no console).

Desenvolvido como parte de um desafio técnico para gerenciamento de pedidos.
