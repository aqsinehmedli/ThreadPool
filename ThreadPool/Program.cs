using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Source: ");
        var source = Console.ReadLine();
        Console.Write("New File: ");
        var destination = Console.ReadLine();

        if (File.Exists(source))
        {
            try
            {
                using (var sourceStream = new FileStream(source, FileMode.Open, FileAccess.Read))
                {
                    if (!Path.HasExtension(destination))
                    {
                        destination = Path.Combine(Path.GetDirectoryName(source), $"{Path.GetFileNameWithoutExtension(source)}Copy{Path.GetExtension(source)}");
                    }

                    if (Path.GetExtension(source) == Path.GetExtension(destination))
                    {
                        using (var destStream = new FileStream(destination, FileMode.Create, FileAccess.Write))
                        {
                            var len = 200;
                            var bytes = new byte[len];

                            while ((len = sourceStream.Read(bytes, 0, bytes.Length)) > 0)
                            {
                                destStream.Write(bytes, 0, len);
                            }
                        }
                        Console.WriteLine($"File copied to {destination}");
                    }
                    else
                    {
                        Console.WriteLine("Choose correct file extension");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong: {ex.Message}");
            }
        }
        else
        {
            Console.WriteLine("File not found");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
