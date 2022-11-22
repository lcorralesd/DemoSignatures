using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoSignatures.Core.Application.DownloadService.Command;
[Route("api/[controller]")]
[ApiController]
public class SaveToFileDownloadController : ControllerBase
{
    private readonly IMediator _mediator;

	public SaveToFileDownloadController(IMediator mediator)
	{
		_mediator= mediator;
	}

	[HttpPost("download")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Download(SaveFileToDownloadCommand command)
	{
		var result = await _mediator.Send(command);

        return result == false ? NotFound() : Ok();
	}
}
