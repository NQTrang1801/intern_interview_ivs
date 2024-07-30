using ExceptionHandlingApp;
using System;

Logger.LogInfo("Application started.");

try
{
    int result = Divide(10, 2);
    Console.WriteLine("Result: " + result);
    Logger.LogInfo("Division successful.");
}
catch (Exception ex)
{
    Logger.LogError(ex, "An exception occurred while performing division");
}

Logger.LogInfo("Application ended.");

static int Divide(int x, int y)
{
    if (x == 0)
    {
        throw new ArgumentException("Denominator cannot be zero.", nameof(x));
    }
    return x / y;
}
