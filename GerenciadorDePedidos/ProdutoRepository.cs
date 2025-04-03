using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDePedidos
{
    class ProdutoRepository
    {
        private const string ConnectionString = "Data Source=pedidos.db";

        public void CadastrarProduto(string nome, double preco, int estoque)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO Produtos (Nome, Preco, Estoque) VALUES (@Nome, @Preco, @Estoque)";
                command.Parameters.AddWithValue("@Nome", nome);
                command.Parameters.AddWithValue("@Preco", preco);
                command.Parameters.AddWithValue("@Estoque", estoque);
                command.ExecuteNonQuery();

                Console.WriteLine("Produto cadastrado com sucesso!");
            }
        }

        public List<Produto> ListarProdutos()
        {
            var produtos = new List<Produto>();

            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT Id, Nome, Preco, Estoque FROM Produtos";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        produtos.Add(new Produto
                        {
                            Id = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Preco = reader.GetDouble(2),
                            Estoque = reader.GetInt32(3)
                        });
                    }
                }
            }

            return produtos;
        }

        public void AtualizarProduto(int id, double novoPreco, int novoEstoque)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "UPDATE Produtos SET Preco = @Preco, Estoque = @Estoque WHERE Id = @Id";
                command.Parameters.AddWithValue("@Preco", novoPreco);
                command.Parameters.AddWithValue("@Estoque", novoEstoque);
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto atualizado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }

        public void RemoverProduto(int id)
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "DELETE FROM Produtos WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto removido com sucesso!");
                }
                else
                {
                    Console.WriteLine("Produto não encontrado.");
                }
            }
        }
    }
}
