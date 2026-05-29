# Sistema de Gerenciamento de Pedidos

## Visão Geral

O **Sistema de Gerenciamento de Pedidos** é uma aplicação de console desenvolvida em C# com banco de dados **SQLite**, voltada para o controle de clientes, produtos e pedidos.

O sistema permite operações completas de CRUD e simula o fluxo real de vendas, incluindo controle de estoque e associação de produtos aos pedidos.

---

## Funcionalidades

- Cadastro de clientes com nome e e-mail  
- Cadastro de produtos com preço e estoque  
- Criação de pedidos vinculados a clientes  
- Adição de múltiplos produtos por pedido  
- Controle automático de estoque  
- Listagem de pedidos por cliente  
- Atualização de dados de clientes e produtos  
- Remoção de clientes, produtos e pedidos  
- Cálculo de valores totais dos pedidos  

---

## Arquitetura do Sistema

O projeto segue uma estrutura simples e organizada em camadas:

### Database
- **Database.cs**: gerencia conexão e operações com SQLite

---

### Entidades

Representam os dados principais do sistema:

- Cliente  
- Produto  
- Pedido  
- ItemPedido  

---

### Repositories

Responsáveis pelas operações de banco de dados (CRUD):

- ClienteRepository  
- ProdutoRepository  
- PedidoRepository  

Cada repository encapsula regras de acesso e manipulação dos dados.

---

### Program

- **Program.cs**: contém o menu principal e controla o fluxo da aplicação

---

## Banco de Dados

O sistema utiliza **SQLite**, com criação automática do banco `pedidos.db` na primeira execução.

### Tabelas

- **Clientes**
  - Id
  - Nome
  - Email

- **Produtos**
  - Id
  - Nome
  - Preco
  - Estoque

- **Pedidos**
  - Id
  - ClienteId
  - DataPedido

- **ItensPedido**
  - Id
  - PedidoId
  - ProdutoId
  - Quantidade
  - PrecoTotal

---

## Como Executar

### Pré-requisitos

- .NET SDK instalado  
- SQLite (gerenciado via pacote `Microsoft.Data.Sqlite`)  
- Editor como Visual Studio ou VS Code  

---

### Passos

1. Clone o repositório:
```bash
git clone https://github.com/maduaperes/GerenciadorDePedidos.git
````

2. Acesse o projeto:

```bash
cd GerenciadorDePedidos
```

3. Restaure dependências:

```bash
dotnet restore
```

4. Execute o projeto:

```bash
dotnet run
```

---

## Menu do Sistema

Ao iniciar, o sistema exibe o menu principal:

```
===== Menu Principal =====

1. Cadastrar Cliente
2. Cadastrar Produto
3. Criar Pedido
4. Listar Pedidos de um Cliente
5. Listar Clientes
6. Listar Produtos
7. Atualizar E-mail de Cliente
8. Atualizar Produto (Preço/Estoque)
9. Remover Cliente
10. Remover Produto
11. Remover Pedido
12. Sair
```

---

## Fluxo de Uso

1. Cadastrar clientes e produtos
2. Criar pedidos vinculando cliente e produtos
3. O sistema verifica estoque automaticamente
4. Consultar pedidos por cliente
5. Atualizar ou remover registros conforme necessário

---

## Objetivo

O objetivo do sistema é praticar:

* Desenvolvimento em C# com console
* Uso de banco de dados SQLite
* Arquitetura em camadas
* Padrão Repository
* Lógica de negócios com controle de estoque

---

## Possíveis Melhorias

* Interface gráfica (WinForms ou WPF)
* Autenticação de usuários
* Relatórios de vendas
* API REST com ASP.NET Core
* Melhor tratamento de erros
* Logs de operações

---
