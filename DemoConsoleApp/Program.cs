// See https://aka.ms/new-console-template for more information
using DemoConsoleApp.Models;
using DemoSignatures.Helper;
using Spectre.Console;
using DemoCSVExtension.Helper;
using System.IO;
using System.Globalization;

var assets = new[]
        {
            "Demo3.jpg",
            "Prueba_mala.csv",
            "ExcelPrueba.csv",
            "Video.mp4",
            "Prueba.csv",
            "Predia Monica.pdf",
            "Libro1.xls"
        };

FileTypeVerifier verifier = new FileTypeVerifier();

Console.WriteLine("\nFile Verification Results\n");
// Identify the file by bytes
foreach (var asset in assets)
{
    var path = Path.Combine("./assets", asset);
    var result = verifier.IsMatch(path, Path.GetExtension(path));
    Console.WriteLine($"{asset} is {result} ");
}

//var personList = new List<Person>
//{
//    new Person(){ FirstName = "Jose, Maria", LastName = "Perez", Address = "Calle 3 lote 5", Salary = 10000.05m, BirthDay = new DateOnly(1980,01,01), Phone = new Phone{Id = 1, Number = "12345"}, IsActive = true },
//    new Person(){ FirstName = "Pedro", LastName = "Diaz", Address = "Calle, 4 lote 8", Salary = 50000.85m, BirthDay = new DateOnly(1990,12,31), Phone = new Phone{Id = 2, Number = "4562545"}, IsActive = false }
//};

//var csv = personList.ToCsvStream();
//var csvFile = personList.ToCsvFile("Prueba.csv");

//StreamReader reader = new StreamReader(csv);
//string text = reader.ReadToEnd();

//Console.WriteLine(text);

