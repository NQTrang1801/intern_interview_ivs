using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    public class DatabaseConnection
    {
        private static DatabaseConnection? _instance = null;
        private static readonly object _lock = new();
        private readonly MySqlConnection _connection;

        private DatabaseConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            _connection = new MySqlConnection(connectionString);
            OpenConnection();
        }

        public static DatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DatabaseConnection();
                    }
                    return _instance;
                }
            }
        }

        public MySqlConnection Connection => _connection;

        public void OpenConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Closed)
                {
                    _connection.Open();
                    Console.WriteLine("MySQL connection opened.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the connection: {ex.Message}");
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (_connection.State == System.Data.ConnectionState.Open)
                {
                    _connection.Close();
                    Console.WriteLine("MySQL connection closed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while closing the connection: {ex.Message}");
            }
        }
    }
}
