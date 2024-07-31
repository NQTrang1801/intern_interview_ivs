using System;
using System.Collections.Generic;
using System.Configuration;
using MySql.Data.MySqlClient;
using MySqlTest;

try
{
    var connection = DatabaseConnection.Instance.Connection;
    DatabaseConnection.Instance.OpenConnection();

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
    DatabaseConnection.Instance.CloseConnection();
}
