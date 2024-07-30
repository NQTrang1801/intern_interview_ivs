using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySqlTest;

string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

using (var connection = new MySqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("MySQL connection opened.");

        IUserRepository userRepository = new UserRepository(connection);

        userRepository.CreateTable();

        userRepository.InsertUser("john_doe", "john.doe@example.com");
        userRepository.InsertUser("jane_doe", "jane.doe@example.com");

        Console.WriteLine("Users:");
        foreach (var user in userRepository.GetAllUsers())
        {
            Console.WriteLine($"ID: {user.Id}, Username: {user.Username}, Email: {user.Email}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
    finally
    {
        connection.Close();
        Console.WriteLine("MySQL connection closed.");
    }
}
