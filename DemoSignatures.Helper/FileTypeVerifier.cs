using DemoSignatures.Helper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper;
public class FileTypeVerifier : IFileTypeVerifier
{
    private IEnumerable<FileType> Types { get; set; }


    private FileTypeVerifyResult Unknown = new FileTypeVerifyResult
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
            new M4a(),
            new OpenXML(),
            new Pdf(),
            new Png(),
            new Zip(),
        }.OrderByDescending(x => x.SignatureLength).ToList();
    }

    public FileTypeVerifyResult Match(string path)
    {
        FileStream file;
        FileTypeVerifyResult? result;
        VerifyType(path, out file, out result);

        return result?.IsVerified == true ? result : Unknown;
    }

    public bool IsMatch(string path)
    {
        FileStream file;
        FileTypeVerifyResult? result;
        VerifyType(path, out file, out result);

        return result?.IsVerified == true ? true : false;
    }

    private void VerifyType(string path, out FileStream file, out FileTypeVerifyResult? result)
    {
        file = File.OpenRead(path);
        result = null;
        foreach (var fileType in Types)
        {
            result = fileType.Verify(file)!;
            if (result.IsVerified) break;
        }
    }
}
