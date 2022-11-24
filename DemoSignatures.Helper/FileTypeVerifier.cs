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
            new Jpeg(),
            new Mp4(),
            new OpenXML(),
            new Pdf(),
            new Png(),
            new Zip(),
            new Mz(),
        }.OrderByDescending(x => x.SignatureLength).ToList();
    }

    public bool IsMatch(string path)
    {
        bool result = false;
        try
        {
            if (Path.GetExtension(path) == ".csv")
            {
                if(!VerifyTypeCsv(path))
                {
                    result = CsvValidationRegularExpression(path);
                }
            }
            else
            {
                FileTypeVerifyResult? fileTypeResult = VerifyType(path);

                result = fileTypeResult!.IsVerified && fileTypeResult.IsExtensionMatch;
            }
        }
        catch (Exception)
        {
            return false;
        }

        return result;
    }

    private bool VerifyTypeCsv(string path)
    {
        var isVerified = false;

        using var file = File.OpenRead(path);

        foreach (var fileType in Types)
        {
            isVerified = fileType.VerifySignatureCsv(file);
            if (isVerified)
            {
                break;
            }
        }
        return isVerified;
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
                if (result == null)
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
            throw (ex);
        }

        return result;
    }

    private static bool CsvValidationRegularExpression(string path)
    {
        return Regex.IsMatch(path, pattern, RegexOptions.Multiline);
    }
}
