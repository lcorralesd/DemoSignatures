using MediatR;

namespace DemoSignatures.Core.Application.DownloadService.Command;

public record SaveFileToDownloadCommand(Guid Id) : IRequest<bool>;
