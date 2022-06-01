namespace RemoveBinaries;

public static class Program
{
    public static int quantity;

    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("This utility allows to delete all binaries from a .NET Solution");
            Console.WriteLine($"Running under {Environment.OSVersion.VersionString}");
            Console.WriteLine($"This operation will run on {Environment.CurrentDirectory} do you want to proceed? [y]/n");

            var key = Console.ReadLine() ?? string.Empty;

            if (key.Equals("n", StringComparison.InvariantCultureIgnoreCase))
                return;

            DeleteFolders(Environment.CurrentDirectory);

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
        Directory.GetDirectories(path)
            .ToList()
            .ForEach(directory =>
            {
                if (directory.EndsWith("\\bin") || directory.EndsWith("\\obj"))
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