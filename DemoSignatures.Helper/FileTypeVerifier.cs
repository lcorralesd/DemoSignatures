using DemoSignatures.Helper.Types;
using System.Text.RegularExpressions;

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
            new Csv(),
            new Jpeg(),
            new Mp4(),
            new OpenXML(),
            new Pdf(),
            new Png(),
            new Zip(),
            new Mz()
        }.OrderByDescending(x => x.SignatureLength).ToList();
    }

    public bool IsMatch(string path)
    {
        bool result = false;
        try
        {
            FileTypeVerifyResult? fileTypeResult = VerifyType(path);

            if (!fileTypeResult.IsVerified && fileTypeResult.IsExtensionMatch)
            {
                if (Path.GetExtension(path).Equals(".csv"))
                {
                    result = CsvValidationRegularExpression(path);
                }
            }
            else
            {
                result = fileTypeResult.IsVerified && fileTypeResult.IsExtensionMatch;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return result;
    }

    private FileTypeVerifyResult? VerifyType(string path)
    {
        FileTypeVerifyResult? result = null;

        FileStream file;
        try
        {
            file = File.OpenRead(path);
            foreach (var fileType in Types)
            {
                result = fileType.Verify(file, Path.GetExtension(path))!;
                if(result == null)
                {
                    result = new FileTypeVerifyResult 
                    {
                        IsExtensionMatch = true,
                        IsVerified = false
                    };
                }
                if (result.IsVerified && result.IsExtensionMatch)
                {
                    break;
                }
            }
            file.Close();
        }
        catch (Exception ex)
        {
            throw(ex);
        }

        return result;
    }

    private static bool CsvValidationRegularExpression(string path)
    {
        return Regex.IsMatch(path, pattern, RegexOptions.Multiline);
    }
}
