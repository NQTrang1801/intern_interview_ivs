using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlTest
{
    public class UserRepository(MySqlConnection connection) : IUserRepository
    {
        private readonly MySqlConnection _connection = connection ?? throw new ArgumentNullException(nameof(connection));

        public void CreateTable()
        {
            const string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Users (
                Id INT AUTO_INCREMENT PRIMARY KEY,
                Username VARCHAR(50) NOT NULL,
                Email VARCHAR(100) NOT NULL UNIQUE
            )";

            using var command = new MySqlCommand(createTableQuery, _connection);
            command.ExecuteNonQuery();
            Console.WriteLine("Table 'Users' created.");
        }

        // Chèn người dùng mới vào bảng Users
        public void InsertUser(string username, string email)
        {
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));

            const string insertQuery = "INSERT INTO Users (Username, Email) VALUES (@Username, @Email)";

            using var command = new MySqlCommand(insertQuery, _connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Email", email);

            int affectedRows = command.ExecuteNonQuery();
            if (affectedRows > 0)
                Console.WriteLine($"User '{username}' inserted successfully.");
            else
                Console.WriteLine("Insert operation failed.");
        }

        // Lấy tất cả người dùng
        public IEnumerable<User> GetAllUsers()
        {
            const string selectQuery = "SELECT * FROM Users";

            using (var command = new MySqlCommand(selectQuery, _connection))
            using (var reader = command.ExecuteReader())
            {
                var users = new List<User>();

                while (reader.Read())
                {
                    users.Add(new User
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Username = reader["Username"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }

                return users;
            }
        }
    }
}
