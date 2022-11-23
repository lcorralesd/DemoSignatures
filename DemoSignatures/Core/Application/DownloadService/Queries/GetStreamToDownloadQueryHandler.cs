using DemoSignatures.Core.Application.DownloadService.Queries;
using DemoSignatures.Core.Domain;
using DemoSignatures.Helper;
using DemoSignatures.Infrastructure.Context;
using MediatR;

namespace DemoSignatures.Core.Application.DownloadService.Command;

public partial class GetStreamToDownloadQueryHandler : IRequestHandler<GetStreamToDownloadQuery, Stream?>
{
    private readonly ApplicationDbContext _context;
    private readonly IFileTypeVerifier _fileTypeVerifier;

    public GetStreamToDownloadQueryHandler(ApplicationDbContext context, IFileTypeVerifier fileTypeVerifier)
    {
        _context = context;
        _fileTypeVerifier = fileTypeVerifier;
    }

    public async Task<Stream?> Handle(GetStreamToDownloadQuery request, CancellationToken cancellationToken)
    {
        Stream? result = null;

        FileEntry? fileEntry = await _context.FileEntries.FindAsync(request.Id, cancellationToken);
        if (fileEntry == null)
        {
            return null;
        }

        try
        {
            bool validFile = _fileTypeVerifier.IsMatch(fileEntry.Path);
            if (validFile)
            {
                string extension = Path.GetExtension(fileEntry.Path);
                var memoryStream = new MemoryStream();
                Stream stream = await FileToStream(fileEntry, memoryStream);
                result = stream;
            }
        }
        catch (Exception)
        {
            result = null;
        }
        return result;
    }

    private async Task<Stream> FileToStream(FileEntry fileEntry, MemoryStream memoryStream)
    {
        using var stream = new FileStream(fileEntry.Path, FileMode.Open, FileAccess.Read, FileShare.Read);
        await stream.CopyToAsync(memoryStream);
        return memoryStream;
    }
}
