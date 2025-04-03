using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using GerenciadorDePedidos;

class ClienteRepository
{
    private const string ConnectionString = "Data Source=pedidos.db";

    public void CadastrarCliente(string nome, string email)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Clientes (Nome, Email) VALUES (@Nome, @Email)";
            command.Parameters.AddWithValue("@Nome", nome);
            command.Parameters.AddWithValue("@Email", email);

            try
            {
                command.ExecuteNonQuery();
                Console.WriteLine("Cliente cadastrado com sucesso!");
            }
            catch (SqliteException)
            {
                Console.WriteLine("Erro: E-mail já cadastrado.");
            }
        }
    }

    public List<Cliente> ListarClientes()
    {
        var clientes = new List<Cliente>();

        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Nome, Email FROM Clientes";

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        Id = reader.GetInt32(0),
                        Nome = reader.GetString(1),
                        Email = reader.GetString(2)
                    });
                }
            }
        }

        return clientes;
    }

    public void AtualizarEmail(int id, string novoEmail)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = "UPDATE Clientes SET Email = @Email WHERE Id = @Id";
            command.Parameters.AddWithValue("@Email", novoEmail);
            command.Parameters.AddWithValue("@Id", id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("E-mail atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado.");
            }
        }
    }

    public void RemoverCliente(int clienteId)
    {
        using (var connection = new SqliteConnection(ConnectionString))
        {
            connection.Open();

            var verificarCommand = connection.CreateCommand();
            verificarCommand.CommandText = "SELECT COUNT(*) FROM Clientes WHERE Id = @clienteId";
            verificarCommand.Parameters.AddWithValue("@clienteId", clienteId);

            var count = Convert.ToInt32(verificarCommand.ExecuteScalar());

            if (count == 0)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Clientes WHERE Id = @clienteId";
            command.Parameters.AddWithValue("@clienteId", clienteId);
            command.ExecuteNonQuery();

            Console.WriteLine("Cliente removido com sucesso.");
        }
    }
}