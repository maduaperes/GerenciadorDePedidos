using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos
{
    class PedidoRepository
    {
        private const string ConnectionString = "Data Source=pedidos.db";

        public int CriarPedido(int clienteId)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"INSERT INTO Pedidos (ClienteId, DataPedido) VALUES (@ClienteId, @DataPedido); SELECT last_insert_rowid();";
                command.Parameters.AddWithValue("@ClienteId", clienteId);
                command.Parameters.AddWithValue("@DataPedido", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                var pedidoId = command.ExecuteScalar();
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        public bool AdicionarItemPedido(int pedidoId, int produtoId, int quantidade)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var estoqueCommand = connection.CreateCommand();
                estoqueCommand.CommandText = "SELECT Estoque, Preco FROM Produtos WHERE Id = @ProdutoId";
                estoqueCommand.Parameters.AddWithValue("@ProdutoId", produtoId);

                using (var reader = estoqueCommand.ExecuteReader())
                {
                    if (!reader.Read() || reader.GetInt32(0) < quantidade)
                    {
                        Console.WriteLine("Erro: Estoque insuficiente ou produto não encontrado.");
                        return false;
                    }

                    double precoUnitario = reader.GetDouble(1);
                    double precoTotal = precoUnitario * quantidade;

                    var insertCommand = connection.CreateCommand();
                    insertCommand.CommandText = "INSERT INTO ItensPedido (PedidoId, ProdutoId, Quantidade, PrecoTotal) VALUES (@PedidoId, @ProdutoId, @Quantidade, @PrecoTotal)";
                    insertCommand.Parameters.AddWithValue("@PedidoId", pedidoId);
                    insertCommand.Parameters.AddWithValue("@ProdutoId", produtoId);
                    insertCommand.Parameters.AddWithValue("@Quantidade", quantidade);
                    insertCommand.Parameters.AddWithValue("@PrecoTotal", precoTotal);
                    insertCommand.ExecuteNonQuery();

                    var updateCommand = connection.CreateCommand();
                    updateCommand.CommandText = "UPDATE Produtos SET Estoque = Estoque - @Quantidade WHERE Id = @ProdutoId";
                    updateCommand.Parameters.AddWithValue("@Quantidade", quantidade);
                    updateCommand.Parameters.AddWithValue("@ProdutoId", produtoId);
                    updateCommand.ExecuteNonQuery();

                    Console.WriteLine("Item adicionado ao pedido com sucesso!");
                    return true;
                }
            }
        }

        public List<Pedido> ListarPedidosCliente(int clienteId)
        {
            var pedidos = new List<Pedido>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, DataPedido FROM Pedidos WHERE ClienteId = @ClienteId";
                command.Parameters.AddWithValue("@ClienteId", clienteId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new Pedido
                        {
                            Id = reader.GetInt32(0),
                            ClienteId = clienteId,
                            DataPedido = reader.GetString(1)
                        });
                    }
                }
            }

            return pedidos;
        }

        public void RemoverPedido(int pedidoId)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();

                var verificarCommand = connection.CreateCommand();
                verificarCommand.CommandText = "SELECT COUNT(*) FROM Pedidos WHERE Id = @pedidoId";
                verificarCommand.Parameters.AddWithValue("@pedidoId", pedidoId);

                var count = Convert.ToInt32(verificarCommand.ExecuteScalar());

                if (count == 0)
                {
                    Console.WriteLine("Pedido não encontrado.");
                    return;
                }

                var removerItensCommand = connection.CreateCommand();
                removerItensCommand.CommandText = "DELETE FROM ItensPedido WHERE PedidoId = @pedidoId";
                removerItensCommand.Parameters.AddWithValue("@pedidoId", pedidoId);
                removerItensCommand.ExecuteNonQuery();

                var removerPedidoCommand = connection.CreateCommand();
                removerPedidoCommand.CommandText = "DELETE FROM Pedidos WHERE Id = @pedidoId";
                removerPedidoCommand.Parameters.AddWithValue("@pedidoId", pedidoId);
                removerPedidoCommand.ExecuteNonQuery();

                Console.WriteLine("Pedido removido com sucesso.");
            }
        }
    }
}
