# Sistema de Gerenciamento de Pedidos

## Descrição

O Sistema de Gerenciamento de Pedidos é uma aplicação de console desenvolvida em C# que permite gerenciar clientes, produtos e pedidos de uma empresa. A aplicação utiliza um banco de dados SQLite para armazenar as informações sobre os clientes, produtos e pedidos, com operações CRUD (Criar, Ler, Atualizar e Deletar) implementadas para cada uma dessas entidades.

O sistema é ideal para pequenas empresas que precisam de uma ferramenta simples e eficiente para gerenciar seus pedidos, produtos em estoque e clientes. Além disso, o sistema permite realizar a criação de pedidos associando produtos aos mesmos e garantindo que os estoques sejam devidamente atualizados.

## Funcionalidades
	•	Cadastro de Clientes: Permite adicionar novos clientes ao sistema com informações como nome e e-mail.
	•	Cadastro de Produtos: Permite adicionar novos produtos, com informações como nome, preço e quantidade em estoque.
	•	Criação de Pedidos: Permite criar pedidos e associá-los a um cliente. Os pedidos podem incluir múltiplos produtos, com a verificação de estoque.
	•	Listagem de Pedidos: Exibe todos os pedidos feitos por um cliente específico, incluindo os produtos comprados e o valor total.
	•	Atualização de Clientes: Permite atualizar o e-mail de um cliente.
	•	Atualização de Produtos: Permite atualizar o preço e a quantidade de estoque de um produto.
	•	Remoção de Clientes e Produtos: Permite excluir clientes e produtos do sistema.
	•	Remoção de Pedidos: Permite excluir um pedido, removendo também os itens associados a ele.

## Estrutura do Sistema

O sistema é estruturado de maneira simples e eficiente, dividindo suas responsabilidades em várias camadas:

	•	Database.cs: Responsável por gerenciar a conexão e as operações no banco de dados SQLite.
	•	Entidades:
	•	Cliente: Representa o cliente no sistema.
	•	Produto: Representa o produto no sistema.
	•	Pedido: Representa o pedido feito por um cliente.
	•	ItemPedido: Representa os itens de um pedido, associando produtos a um pedido.
	•	Repositories:
	•	ClienteRepository: Contém métodos para operações CRUD relacionadas aos clientes.
	•	ProdutoRepository: Contém métodos para operações CRUD relacionadas aos produtos.
	•	PedidoRepository: Contém métodos para operações CRUD relacionadas aos pedidos e itens de pedidos.
	•	Program.cs: Contém o menu interativo e a lógica de execução do sistema.

## Como Rodar

Pré-requisitos

	•      .NET SDK: O sistema foi desenvolvido utilizando o .NET SDK. Você precisa ter o .NET SDK instalado em sua máquina para rodar o projeto. Você pode baixá-lo em dotnet.microsoft.com.
	•      SQLite: O banco de dados SQLite é utilizado para persistir as informações. O pacote Microsoft.Data.Sqlite foi incluído no projeto para facilitar a interação com o banco.

## Passos para Executar

	•	Clone o repositório.
	•	Abra o projeto no Visual Studio ou no editor de sua preferência.
	•	Restaure as dependências do projeto:
	•	Abra o terminal e execute o comando:
	•	Crie o banco de dados SQLite:
	•	O banco de dados pedidos.db será criado automaticamente quando o sistema for executado pela primeira vez. 
                Ele será inicializado com as tabelas necessárias para o funcionamento do sistema.
	•	Para rodar o sistema, execute o comando:
	•	Execute o sistema:
	•	Interaja com o sistema:
	•	Após rodar o comando acima, o sistema será iniciado no terminal e exibirá o menu com opções de gerenciamento 
                de clientes, produtos, pedidos, etc.

## Exemplo de Execução

Ao iniciar o sistema, o menu será exibido no terminal:

===== Menu Principal =====
1. Cadastrar Cliente
2. Cadastrar Produto
3. Criar Pedido
4. Listar Pedidos de um Cliente
5. Listar Clientes
6. Listar Produtos
7. Atualizar E-mail de Cliente
8. Atualizar Produto (Preço/Estoque)
9. Remover Cliente
10. Remover Produto
11. Remover Pedido
12. Sair
Escolha uma opção:
Escolha uma opção digitando o número correspondente e siga as instruções para interagir com o sistema.

## Estrutura de Banco de Dados

O banco de dados SQLite contém as seguintes tabelas:

	•	Clientes: Armazena informações sobre os clientes.
	•	Produtos: Armazena informações sobre os produtos disponíveis.
	•	Pedidos: Armazena os pedidos feitos pelos clientes.
	•	ItensPedido: Armazena os itens de cada pedido, associando produtos e quantidade.

## Tabelas
	•	Clientes: Id, Nome, Email
	•	Produtos: Id, Nome, Preco, Estoque
	•	Pedidos: Id, ClienteId, DataPedido
	•	ItensPedido: Id, PedidoId, ProdutoId, Quantidade, PrecoTotal
