using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper;
public class CsvValidate
{
    public static bool Validate(string path)
    {
        bool result = false;

        using StreamReader archivo = new StreamReader(path);
        string separador = ",";
        string? linea;
        // Si el archivo no tiene encabezado, elimina la siguiente línea
        //archivo.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado
        while ((linea = archivo.ReadLine()) != null)
        {
            string[] fila = linea.Split(separador);
            Console.WriteLine($"Encabezado 1 { fila } ");
            result= true;
        }
        Console.WriteLine("--");

        return result;
    }
}
