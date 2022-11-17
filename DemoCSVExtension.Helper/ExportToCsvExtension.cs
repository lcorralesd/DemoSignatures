using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DemoCSVExtension.Helper;
public static class ExportToCsvExtension
{
    //awesomeness!! XD
    //found this at http://mikehadlow.blogspot.com/2008/06/linq-to-csv.html tweaked and fixed it
    private static string ToCsvValue<T>(this T item) where T : class
    {
        //var valorDecimalToStr = item.ToString();
        //NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        if (item == null)
        {
            return "";
        }
        if (item is string)
        {
            var result = String.Format("\"{0}\"", item.ToString()!.Replace("\"", "\""));
            return result;
        }
        if (item is decimal)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            return item.ToString()!;
        }
        if (item is DateOnly || item is bool)
        {
            var result = String.Format("{0}", item);
            return result;
        }
        double dummy;
        if (double.TryParse(item.ToString(), out dummy))
        {
            var result = String.Format("{0}", item);
            return result;
        }
        if (item is object)
        {
            var result = "N/A";
            return result;
        }
        var resultFinal = String.Format("{0}", item);

        return resultFinal;
    }
    public static Stream ToCsvStream<T>(this IEnumerable<T> items) where T : class
    {
        var csvBuilder = new StringBuilder();
        var properties = typeof(T).GetProperties();
        var prop = properties.Select(p => p.Name.ToCsvValue());
        csvBuilder.AppendLine(String.Join(",", prop.ToArray()));
        foreach (T item in items)
        {
            string line = String.Join(",", properties.Select(p => p.GetValue(item, null)!.ToCsvValue()).ToArray());
            csvBuilder.AppendLine(line);
        }

        byte[] byteArray = Encoding.ASCII.GetBytes(csvBuilder.ToString());
        MemoryStream stream = new MemoryStream(byteArray);
        return stream;
    }

    public static string ToCsvFile<T>(this IEnumerable<T> items, string fileName) where T : class
    {
        CopyStream(ToCsvStream<T>(items), $"D:\\{fileName}");
        return "";
    }

    private static void CopyStream(Stream source, string destination)
    {
        using var fileStream = new FileStream(destination, FileMode.Create, FileAccess.Write);
        source.CopyTo(fileStream);
    }
}
