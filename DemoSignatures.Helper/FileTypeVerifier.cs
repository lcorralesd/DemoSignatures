using DemoSignatures.Helper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DemoSignatures.Helper;
public class FileTypeVerifier : IFileTypeVerifier
{
    private const string pattern = ",?\".+?\"|[^\"]+?(?=,)|[^\"]+";
    private IEnumerable<FileType> Types { get; set; }

    private readonly FileTypeVerifyResult Unknown = new FileTypeVerifyResult
    {
        Name = "Unknown",
        Description = "Unknown File Type",
        Extension = "Unknown",
        IsVerified = false,
    };

    public FileTypeVerifier()
    {
        Types = new List<FileType>
        {
            new CompoundBinary(),
            //new Csv(),
            new Jpeg(),
            new Mp4(),
            new OpenXML(),
            new Pdf(),
            new Png(),
            new Zip(),
        }.OrderByDescending(x => x.SignatureLength).ToList();
    }

    public FileTypeVerifyResult Match(string path, string extension)
    {
        VerifyType(path, extension, out _, out FileTypeVerifyResult? result);

        return result?.IsVerified == true ? result : Unknown;
    }

    public bool IsMatch(string path, string extension)
    {
        bool result;
        if (extension.Equals(".csv"))
        {
            result = CsvValidationRegularExpression(path);
        }
        else
        {
            VerifyType(path, extension, out _, out FileTypeVerifyResult? varifyResult);

            result = varifyResult?.IsVerified == true;
        }

        return result;
    }

    private void VerifyType(string path, string extension, out FileStream file, out FileTypeVerifyResult? result)
    {
        file = File.OpenRead(path);
        
        result = null;
        foreach (var fileType in Types)
        {
            result = fileType.Verify(file, extension)!;
            if (result.IsVerified)
            {
                break;
            }
        }
    }

    private static bool CsvValidationRegularExpression(string path)
    {
        return Regex.IsMatch(path, pattern, RegexOptions.Multiline);
    }
}
