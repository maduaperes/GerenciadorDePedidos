using Microsoft.Data.Sqlite;
using System;
using System.IO;

class Database
{
    private const string DatabaseFile = "pedidos.db";

    public static void Initialize()
    {
        if (!File.Exists(DatabaseFile))
        {
            using (var connection = new SqliteConnection($"Data Source={DatabaseFile}"))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"
                    CREATE TABLE Clientes (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Email TEXT UNIQUE NOT NULL
                    );

                    CREATE TABLE Produtos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL NOT NULL,
                        Estoque INTEGER NOT NULL
                    );

                    CREATE TABLE Pedidos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        ClienteId INTEGER NOT NULL,
                        DataPedido TEXT NOT NULL,
                        FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                    );

                    CREATE TABLE ItensPedido (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        PedidoId INTEGER NOT NULL,
                        ProdutoId INTEGER NOT NULL,
                        Quantidade INTEGER NOT NULL,
                        PrecoTotal REAL NOT NULL,
                        FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
                        FOREIGN KEY (ProdutoId) REFERENCES Produtos(Id)
                    );
                ";
                command.ExecuteNonQuery();
            }
            Console.WriteLine("Banco de dados criado com sucesso!");
        }
    }
}