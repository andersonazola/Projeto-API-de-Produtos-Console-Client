# Projeto API .NET - Arquitetura em Camadas

Este é um projeto de estudo desenvolvido em **.NET 8** focado em boas práticas de arquitetura de software com isolamento de responsabilidades

## Tecnologias Utilizadas
*   **.NET 8 (C#)**
*   **Entity Framework Core**
*   **SQLite**
*   **Swagger**

---

## Estrutura do Projeto 

O ecossistema do projeto foi dividido em bibliotecas de classes separadas:

*   **`Produto.Api`**: Contém os *Controllers* responsáveis por receber as requisições HTTP, validar os DTOs (`Requisicao`/`Resposta`) e retornar as respostas adequadas.
*   **`Produto.Aplicacao`**: Orquestra o fluxo dos casos de uso, aplicando regras de negócio e fazendo a ponte entre a API e as outras camadas.
*   **`Produto.Dominio`**: Contém as entidades principais e as interfaces (contratos) que ditam as regras do sistema.
*   **`Produto.Repositorio`**: Camada de infraestrutura de dados. Lida diretamente com o banco de dados (Contexto do EF Core, Migrations e queries).
*   **`Produto.Servicos`**: Camada dedicada a integrações operacionais e serviços externos (atualizações futuras).

---

## Boas Práticas Implementadas

*   **Conventional Commits**: Padronização de mensagens de commit para manter o histórico do Git limpo e legível.
*   **Uso de DTOs**: Isolamento completo das entidades de domínio, garantindo que dados sensíveis não sejam expostos diretamente nas requisições da API.
*   **Injeção de Dependência**: Uso do contêiner nativo do .NET no `Program.cs` para gerenciamento do ciclo de vida dos serviços (`AddScoped`).

---

