namespace DemoSignatures.Helper;

public interface IFileTypeVerifier
{
    FileTypeVerifyResult Match(string path);
    bool IsMatch(string path);
}