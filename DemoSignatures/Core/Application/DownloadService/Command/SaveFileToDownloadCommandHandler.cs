using DemoSignatures.Core.Domain;
using DemoSignatures.Helper;
using DemoSignatures.Infrastructure.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DemoSignatures.Core.Application.DownloadService.Command;

public partial class SaveFileToDownloadCommandHandler : IRequestHandler<SaveFileToDownloadCommand, bool>
{
    private readonly ApplicationDbContext _context;
    private readonly IFileTypeVerifier _fileTypeVerifier;

    public SaveFileToDownloadCommandHandler(ApplicationDbContext context, IFileTypeVerifier fileTypeVerifier)
    {
        _context = context;
        _fileTypeVerifier = fileTypeVerifier;
    }

    public async Task<bool> Handle(SaveFileToDownloadCommand request, CancellationToken cancellationToken)
    {
        FileEntry? fileEntry = await _context.FileEntries.FindAsync(request.Id);
        if (fileEntry == null)
        {
            return false;
        }
        var validFile = _fileTypeVerifier.IsMatch(fileEntry.Path);
        var extension = Path.GetExtension(fileEntry.Path);

        var myConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        string destinationPath = myConfig.GetValue<string>("File:path");

        string destination = Path.GetDirectoryName(destinationPath)!;

        if (!Directory.Exists(destination))
        {
            Directory.CreateDirectory(destination);
        }

        var memoryStream = new MemoryStream();
        await FileToStream(fileEntry, memoryStream);
        await StreamToFile(extension, destinationPath, memoryStream);

        return true;
    }

    private static async Task StreamToFile(string extension, string destinationPath, MemoryStream memoryStream)
    {
        memoryStream.Position = 0;

        var archivoConNombre = $"{destinationPath}\\archivo-{Guid.NewGuid()}{extension}";
        var fileStream = new FileStream(archivoConNombre, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
        await memoryStream.CopyToAsync(fileStream);
    }

    private static async Task FileToStream(FileEntry fileEntry, MemoryStream memoryStream)
    {
        var stream = new FileStream(fileEntry.Path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
        await stream.CopyToAsync(memoryStream);
    }
}
