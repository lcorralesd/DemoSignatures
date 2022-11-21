namespace DemoSignatures.Helper;
public abstract class FileType
{
    protected string Description { get; set; }
    protected string Name { get; set; }
    protected string MediaType { get; set; }
    protected int Offset { get; set; }

    private List<string> Extensions { get; } = new();
    private List<byte[]> Signatures { get; } = new();

    public int SignatureLength => Signatures.Max(m => m.Length);

    protected FileType AddExtensions(params string[] extensions)
    {
        Extensions.AddRange(extensions);
        return this;
    }
    protected FileType AddSignatures(params byte[][] bytes)
    {
        Signatures.AddRange(bytes);
        return this;
    }

    public FileTypeVerifyResult? Verify(Stream stream, string extension)
    {
        FileTypeVerifyResult? result = null;
        if (stream == null || Offset > stream.Length)
        {
            result = null;
        }

        stream!.Position = Offset;
        var reader = new BinaryReader(stream);
        var headerBytes = reader.ReadBytes(SignatureLength);
        result = new FileTypeVerifyResult
        {
            IsVerified = Signatures.Any(signature =>
                headerBytes.Take(signature.Length).SequenceEqual(signature) &&
                Extensions.Any(x => x.Contains(extension.ToLower())))
        };

        return result;
    }
}