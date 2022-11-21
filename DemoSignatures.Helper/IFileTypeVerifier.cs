namespace DemoSignatures.Helper;

public interface IFileTypeVerifier
{
    FileTypeVerifyResult Match(string path, string extension);
    bool IsMatch(string path, string extension);
}