// See https://aka.ms/new-console-template for more information
using DemoSignatures.Helper;

var assets = new[]
        {
            "Demo3.jpg",
            "Prueba_mala.csv",
            "ExcelPrueba.csv",
            "Video.mp4",
            "Prueba.csv",
            "Vacio.pdf",
            "DemoConsoleApp.csv",
            "ArchivoPredial.pdf",
            "ArchivoPdfConExtensionCambiada.csv",
            "Libro1.xls"
        };

FileTypeVerifier verifier = new FileTypeVerifier();

Console.WriteLine("\nFile Verification Results\n");
// Identify the file by bytes
foreach (var asset in assets)
{
    var path = Path.Combine("D:\\Assets", asset);
    var result = verifier.IsMatch(path);
    Console.WriteLine($"{asset} is {result} ");
}
