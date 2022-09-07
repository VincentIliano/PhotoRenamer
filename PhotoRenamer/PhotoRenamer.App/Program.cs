// See https://aka.ms/new-console-template for more information
using System.Reflection;

var fileName = "Names.txt";
var outputFolderName = "Output";
var photoFiletype = ".jpg";

var executingDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
var outputDirectory = $"{executingDirectory}\\{outputFolderName}";

var files = Directory.GetFiles(executingDirectory, $"*{photoFiletype}");
Array.Sort(files);

var names = File.ReadAllLines($"{executingDirectory}\\{fileName}");

Directory.CreateDirectory(outputDirectory);

for (int i = 0; i < files.Length; i++)
{
    File.Copy(files[i], $"{outputDirectory}\\{names[i]}{photoFiletype}", true);
    Console.WriteLine($"{files[i]} renamed to {names[i]}{photoFiletype}");
}

Console.ReadLine();