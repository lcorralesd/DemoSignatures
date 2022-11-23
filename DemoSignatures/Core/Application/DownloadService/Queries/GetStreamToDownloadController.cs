using DemoSignatures.Core.Application.DownloadService.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSignatures.Core.Application.DownloadService.Queries;
[Route("api/[controller]")]
[ApiController]
public class GetStreamToDownloadController : ControllerBase
{
    private readonly IMediator _mediator;

    public GetStreamToDownloadController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFileToDownload(Guid id)
    {
        var result = await _mediator.Send(new GetStreamToDownloadQuery(id));

        return result == null ? NotFound() : Ok(result);
    }
}
