using Microsoft.AspNetCore.Authorization;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet]
    public async Task< IActionResult > GetAll(CancellationToken cancellationToken = default)
    {
        var polls = await _pollService.GetAllAsync(cancellationToken);

        var response = polls.Adapt<IEnumerable<PollResponse>>();

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id , CancellationToken cancellationToken = default)
    {
        var result = await _pollService.GetByIdAsync(id, cancellationToken);

        return result.IsSuccess 
            ? Ok(result.Value) 
            : result.ToProblem(StatusCodes.Status404NotFound);

    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var newPoll = await _pollService.AddAsync(request , cancellationToken);
        
        return CreatedAtAction(nameof(GetById), new { id = newPoll.Id }, newPoll.Adapt<PollResponse>() );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.UpdateAsync(id, request, cancellationToken);

        
        return result.IsSuccess 
            ? NoContent() 
            : result.ToProblem(StatusCodes.Status404NotFound);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.DeleteAsync(id, cancellationToken);

        return result.IsSuccess 
            ? NoContent() 
            : result.ToProblem(StatusCodes.Status404NotFound);
    }

    [HttpPut("{id}/togglePublish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.TogglePublishStatusAsync(id, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProblem(StatusCodes.Status404NotFound);
    }
}

