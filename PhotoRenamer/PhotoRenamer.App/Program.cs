try
{
    var outputFolderName = "Output";
    var photoFiletype = ".jpg";

    var executingDirectory = Environment.CurrentDirectory;
    var outputDirectory = $"{executingDirectory}\\{outputFolderName}";

    var photos = Directory.GetFiles(executingDirectory, $"*{photoFiletype}");
    Array.Sort(photos);

    var txtFiles = Directory.GetFiles(executingDirectory, "*.txt");

    if (txtFiles.Length < 1)
        throw new Exception("there's no txt file");
    if (txtFiles.Length > 1)
        throw new Exception("there's more than one txt file");

    var names = File.ReadAllLines(txtFiles[0]);

    if (photos.Length > names.Length)
        throw new Exception("there are more photos than names");
    if (photos.Length < names.Length)
        throw new Exception("there are more names than photos");

    Directory.CreateDirectory(outputDirectory);

    for (int i = 0; i < photos.Length; i++)
    {
        File.Copy(photos[i], $"{outputDirectory}\\{names[i]}{photoFiletype}", true);
        Console.WriteLine($"{photos[i]} renamed to {names[i]}{photoFiletype}");
    }
    Console.WriteLine($"");
    Console.WriteLine($"All done!");
}
catch (Exception ex)
{
    Console.WriteLine($"You fool, {ex.Message}!");
}

Console.ReadLine();