using System;
using System.IO;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using ExceptionHandlingApp;

string folderPath = "C:\\TestFolder";

try
{
    if (!Directory.Exists(folderPath))
    {
        Directory.CreateDirectory(folderPath);
        Logger.LogInfo("Folder created: " + folderPath);
    }

    if (!HasPermissions(folderPath, FileSystemRights.WriteData | FileSystemRights.Delete))
    {
        throw new UnauthorizedAccessException("The program does not have the necessary permissions to the folder.");
    }

    string[] files = Directory.GetFiles(folderPath);
    var deletionTasks = new ConcurrentBag<Task>();

    foreach (var file in files)
    {
        deletionTasks.Add(DeleteFileAsync(file));
    }

    await Task.WhenAll(deletionTasks);

    Logger.LogInfo("Files deleted successfully.");
}
catch (UnauthorizedAccessException uae)
{
    Logger.LogError(uae, "Access error");
}
catch (Exception ex)
{
    Logger.LogError(ex, "An error occurred");
}

static bool HasPermissions(string folderPath, FileSystemRights rights)
{
    try
    {
        var directoryInfo = new DirectoryInfo(folderPath);
        var security = directoryInfo.GetAccessControl();
        var rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));

        foreach (AuthorizationRule rule in rules)
        {
            if (rule is FileSystemAccessRule fileSystemAccessRule)
            {
                if ((fileSystemAccessRule.FileSystemRights & rights) == rights)
                {
                    return true;
                }
            }
        }
    }
    catch (UnauthorizedAccessException)
    {
        return false;
    }

    return false;
}

static async Task DeleteFileAsync(string file)
{
    try
    {
        await Task.Run(() => File.Delete(file));
        Logger.LogInfo("Deleted file: " + file);
    }
    catch (Exception fileEx)
    {
        Logger.LogError(fileEx, "Error deleting file: " + file);
    }
}
