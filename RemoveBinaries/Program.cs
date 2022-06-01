using System.CommandLine;

namespace RemoveBinaries;

public static class Program
{
    public static int quantity;

    public static void Main(string[] args)
    {
        var pathOption = new Option<string>(
            "--path",
            getDefaultValue: () => Environment.CurrentDirectory,
            description: "The path that contains the Solution File"
        );

        var rootCommand = new RootCommand{
            pathOption
        };

        rootCommand.Description = "Depurador Bin @ Erick Orlando";
        rootCommand.SetHandler((string path) => {
            MainMethod(path);
        }, pathOption);

        rootCommand.Invoke(args);
    }


    ///<summary>
    /// Delete the binary files from a path that contains .NET Projects
    ///</summary>
    /// <param name="path">The path that contains the Solution File</param>
    public static void MainMethod(string path)
    {
        try
        {
            char separator = '*';
            char border = '-';
            int length = 100;

            if (string.IsNullOrEmpty(path))
                path = Environment.CurrentDirectory;

            Console.WriteLine(new string(separator, length));
            Console.WriteLine($"{new string(separator, 10)} This utility allows you to delete all binaries from a .NET Solution");
            Console.WriteLine($"{new string(separator, 10)} Running under {Environment.OSVersion.VersionString}");
            Console.WriteLine(new string(separator, length));

            Console.WriteLine(new string(border, length));
            Console.WriteLine($"This operation will run on {path} do you want to proceed? [y]/n");
            Console.WriteLine(new string(border, length));

            var key = Console.ReadLine() ?? string.Empty;

            if (key.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                return;

            DeleteFolders(path);

            Console.WriteLine("Process Exited with {0} deletions", quantity);
            Console.WriteLine("Erick Orlando © 2022");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadLine();
    }

    public static void DeleteFolders(string path)
    {
        var separator = !Environment.OSVersion.VersionString.Contains("Windows", StringComparison.InvariantCultureIgnoreCase) 
                ? "/" : "\\";

        Directory.GetDirectories(path)
            .ToList()
            .ForEach(directory =>
            {
                if (directory.EndsWith($"{separator}bin") || directory.EndsWith($"{separator}obj"))
                {
                    try
                    {
                        Directory.Delete(directory, true);
                        Console.WriteLine("Deleting {0} ...", directory);
                        quantity++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Can't delete {0}:{1}", directory, ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Searching in {0}... ", directory);
                    DeleteFolders(directory);
                }
            });
    }
}