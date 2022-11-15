using DemoSignatures.Helper.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSignatures.Helper;
public static class FileTypeVerifier
{
    private static IEnumerable<FileType> Types { get;set; }


    private static FileTypeVerifyResult Unknown = new FileTypeVerifyResult
    {
        Name = "Unknown",
        Description = "Unknown File Type",
        IsVerified= false,
    };

    static FileTypeVerifier()
    {
        Types = new List<FileType> 
        {
            new Bmp(),
            new CompoundBinary(),
            new Jpeg(),
            new Mp3(),
            new OpenXML(),
            new Pdf(),
            new Png(),
            new Txt(),
            new Zip(),
        }.OrderByDescending(x => x.SignatureLength).ToList();
    }

    public static FileTypeVerifyResult Match(string path)
    {
        using var file = File.OpenRead(path);
        FileTypeVerifyResult result = null;

        foreach (var fileType in Types)
        {
            result = fileType.Verify(file);
            if (result.IsVerified) break;
        }

        return result?.IsVerified == true? result : Unknown;
    }
}
