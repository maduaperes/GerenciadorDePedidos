using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos
{
    class Program
    {
        static void Main()
        {
            Database.Initialize();
            ClienteRepository clienteRepo = new ClienteRepository();
            ProdutoRepository produtoRepo = new ProdutoRepository();
            PedidoRepository pedidoRepo = new PedidoRepository();

            while (true)
            {
                Console.WriteLine("\n===== Menu Principal =====");
                Console.WriteLine("1. Cadastrar Cliente");
                Console.WriteLine("2. Cadastrar Produto");
                Console.WriteLine("3. Criar Pedido");
                Console.WriteLine("4. Adicionar Item ao Pedido");
                Console.WriteLine("5. Listar Pedidos");
                Console.WriteLine("6. Listar Clientes");  
                Console.WriteLine("7. Listar Produtos");  
                Console.WriteLine("8. Atualizar Cliente");
                Console.WriteLine("9. Atualizar Produto");
                Console.WriteLine("10. Remover Cliente");
                Console.WriteLine("11. Remover Produto");
                Console.WriteLine("12. Remover Pedido");
                Console.WriteLine("13. Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Nome: ");
                        string nomeCliente = Console.ReadLine();
                        Console.Write("E-mail: ");
                        string email = Console.ReadLine();
                        clienteRepo.CadastrarCliente(nomeCliente, email);
                        break;

                    case "2":
                        Console.Write("Nome do Produto: ");
                        string nomeProduto = Console.ReadLine();
                        Console.Write("Preço: ");
                        double preco = double.Parse(Console.ReadLine());
                        Console.Write("Estoque: ");
                        int estoque = int.Parse(Console.ReadLine());
                        produtoRepo.CadastrarProduto(nomeProduto, preco, estoque);
                        break;

                    case "3":
                        Console.Write("ID do Cliente: ");
                        int clienteId = int.Parse(Console.ReadLine());
                        int pedidoId = pedidoRepo.CriarPedido(clienteId);
                        Console.WriteLine($"Pedido {pedidoId} criado com sucesso!");
                        break;

                    case "4":
                        Console.Write("ID do Pedido: ");
                        int pedidoIdItem = int.Parse(Console.ReadLine());
                        Console.Write("ID do Produto: ");
                        int produtoId = int.Parse(Console.ReadLine());
                        Console.Write("Quantidade: ");
                        int quantidade = int.Parse(Console.ReadLine());
                        pedidoRepo.AdicionarItemPedido(pedidoIdItem, produtoId, quantidade);
                        break;

                    case "5":
                        Console.Write("ID do Cliente: ");
                        int idCliente = int.Parse(Console.ReadLine());
                        List<Pedido> pedidos = pedidoRepo.ListarPedidosCliente(idCliente);

                        if (pedidos.Count == 0)
                        {
                            Console.WriteLine("Nenhum pedido encontrado.");
                        }
                        else
                        {
                            Console.WriteLine("\n===== Pedidos do Cliente =====");
                            foreach (var pedido in pedidos)
                            {
                                Console.WriteLine($"Pedido ID: {pedido.Id}, Data: {pedido.DataPedido}");
                            }
                        }
                        break;

                    case "6":  
                        List<Cliente> clientes = clienteRepo.ListarClientes();
                        Console.WriteLine("\n===== Lista de Clientes =====");
                        foreach (var cliente in clientes)
                        {
                            Console.WriteLine($"ID: {cliente.Id}, Nome: {cliente.Nome}, E-mail: {cliente.Email}");
                        }
                        break;

                    case "7":  
                        List<Produto> produtos = produtoRepo.ListarProdutos();
                        Console.WriteLine("\n===== Lista de Produtos =====");
                        foreach (var produto in produtos)
                        {
                            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Preço: {produto.Preco}, Estoque: {produto.Estoque}");
                        }
                        break;

                    case "8":  
                        Console.Write("ID do Cliente: ");
                        int idAtualizarCliente = int.Parse(Console.ReadLine());
                        Console.Write("Novo E-mail: ");
                        string novoEmail = Console.ReadLine();
                        clienteRepo.AtualizarEmail(idAtualizarCliente, novoEmail);
                        break;

                    case "9":  
                        Console.Write("ID do Produto: ");
                        int idAtualizarProduto = int.Parse(Console.ReadLine());
                        Console.Write("Novo Preço: ");
                        double novoPreco = double.Parse(Console.ReadLine());
                        Console.Write("Novo Estoque: ");
                        int novoEstoque = int.Parse(Console.ReadLine());
                        produtoRepo.AtualizarProduto(idAtualizarProduto, novoPreco, novoEstoque);
                        break;

                    case "10":
                        Console.Write("ID do Cliente a remover: ");
                        int idRemoverCliente = int.Parse(Console.ReadLine());
                        clienteRepo.RemoverCliente(idRemoverCliente);
                        break;

                    case "11":
                        Console.Write("ID do Produto a remover: ");
                        int idRemoverProduto = int.Parse(Console.ReadLine());
                        produtoRepo.RemoverProduto(idRemoverProduto);
                        break;

                    case "12":  
                        Console.Write("ID do Pedido a remover: ");
                        int idRemoverPedido = int.Parse(Console.ReadLine());
                        
                        pedidoRepo.RemoverPedido(idRemoverPedido);
                        break;

                    case "13":
                        Console.WriteLine("Saindo...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}