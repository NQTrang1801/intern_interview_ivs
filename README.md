# .NET Exam Review

## Exam/DemoWinForm.cs

### Comments:
1. Use the 'using' statement to ensure resources are released after using `StreamReader` and `StreamWriter`.
2. Use asynchronous methods (async/await) to prevent the UI from freezing during I/O operations.
3. Add a file size check to determine the appropriate reading method:
   - For large files, use `StreamReader.ReadLineAsync` instead of `ReadToEnd` or `ReadAllTextAsync` to minimize memory usage.
   - Use `StringBuilder` to efficiently construct the file content, reducing the number of string objects created in memory.
4. Separate file processing logic into `LoadFileAsync` and `SaveFileAsync` methods for clearer and more maintainable code.
5. Add specific exception handling to manage errors in more detail, facilitating easier error identification and resolution.

## Exam/DemoMySQL.cs

### Comments:
1. Syntax Error:
   - `MySqlConnection connection == new MySqlConnection(connectionString);` should be changed to `MySqlConnection connection = new MySqlConnection(connectionString);`.
2. Use the 'using' statement to ensure resources are released correctly.
3. Store configuration in `App.config` to secure connection information.
4. Implement the Singleton Pattern to ensure only one database connection is created and used throughout the application.
5. Implement the Repository Pattern:
   - Move logic for creating tables, inserting data, and querying data to a `UserRepository` class for better scalability and maintainability.
   - Initialize a `User` model using `IUserRepository` and `UserRepository` to manage data access.
6. Validate input data when inserting to ensure data integrity.
7. Use parameters to prevent SQL Injection.
8. Improve error messages and exception handling for better diagnostics.

## Exam/DemoLog.cs

### Comments:
1. Replace `LogException` method with a `Logger` class to manage logging methods (`LogInfo`, `LogWarning`, `LogError`, `LogDebug`) with a format that includes time, level, and message.
2. Use `StreamWriter` with the `using` keyword to ensure resources are released correctly.
3. Log program start and end information in `Main`, and capture and log any exceptions that occur during execution.
4. Check for division by zero and catch exceptions to prevent runtime errors.

## Exam/DemoFile.cs

### Comments:
1. Reuse the `Logger` class from the previous example to log information.
2. Add a function `HasPermission` to check write and delete permissions on the directory. If permissions are lacking, throw an `UnauthorizedAccessException`.
3. Use `ConcurrentBag<Task>` to manage file deletion tasks in parallel and use `await Task.WhenAll` to wait for all tasks to complete, improving performance.
4. Define `DeleteFileAsync` to asynchronously delete files, avoiding blocking the main thread.

---

Source: [Net Exam.docx](https://github.com/user-attachments/files/16434076/Net.Exam.docx)

