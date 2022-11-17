namespace DemoSignatures.Helper;
public abstract class FileType
{
    protected string Description { get; set; }
    protected string Name { get; set; }

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

    public FileTypeVerifyResult Verify(Stream stream)
    {
        stream.Position = 0;
        var reader = new BinaryReader(stream);
        var headerBytes = reader.ReadBytes(SignatureLength);

        return new FileTypeVerifyResult
        {
            Name = Name,
            Description = Description,
            IsVerified = Signatures.Any(signature =>
                headerBytes.Take(signature.Length).SequenceEqual(signature))
        };
    }
}

//    private List<FileFormat> FindMatchingFormats(Stream stream)
//    {
//        var candidates = _formats
//            .OrderBy(t => t.HeaderLength)
//            .ToList();

//        for (int i = 0; i < candidates.Count; i++)
//        {
//            if (!candidates[i].IsMatch(stream))
//            {
//                candidates.RemoveAt(i);
//                i--;
//            }
//        }

//        if (candidates.Count > 1)
//        {
//            var readers = candidates.OfType<IFileFormatReader>().ToList();

//            if (readers.Any())
//            {
//                var file = readers[0].Read(stream);
//                foreach (var reader in readers)
//                {
//                    if (!reader.IsMatch(file))
//                    {
//                        candidates.Remove((FileFormat)reader);
//                    }
//                }
//            }
//        }

//        stream.Position = 0;
//        return candidates;
//    }
//}
