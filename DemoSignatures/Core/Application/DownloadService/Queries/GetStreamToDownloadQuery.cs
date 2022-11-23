using MediatR;

namespace DemoSignatures.Core.Application.DownloadService.Queries;

public record GetStreamToDownloadQuery(Guid Id) : IRequest<Stream?>;
