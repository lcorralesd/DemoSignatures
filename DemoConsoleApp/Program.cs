// See https://aka.ms/new-console-template for more information
using DemoSignatures.Helper;
using Spectre.Console;

var assets = new[]
        {
            "FromLayersToVerticalSlices es.pdf",
            "FromLayersToVerticalSlices.zip",
            "Predia Monica.pdf",
            "TextFile1.txt",
            "Libro1.xls",
            "Documento de Prueba.docx",
            "perfil.jpg"
        };

Console.WriteLine("\nFile Verification Results\n");
// Identify the file by bytes
foreach (var asset in assets)
{
    var path = Path.Combine("./assets", asset);
    var result = FileTypeVerifier.Match(path);
    Console.WriteLine($"{asset} is a {result.Name} ({result.Description}).");
}
