using Microsoft.AspNetCore.Authorization;
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    // TODO add mapster and modify the code
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
        var poll = await _pollService.GetByIdAsync(id, cancellationToken);

        if (poll is null)
            return NotFound();


        var response = poll.Adapt<PollResponse>();

        return Ok(response);
    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var newPoll = await _pollService.AddAsync(request.Adapt<Poll>() , cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = newPoll.Id }, newPoll);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var isUpdated = await _pollService.UpdateAsync(id, request.Adapt<Poll>() , cancellationToken);
        return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var isDeleted = await _pollService.DeleteAsync(id, cancellationToken);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }

    [HttpPut("{id}/togglePublish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int id,  CancellationToken cancellationToken = default)
    {
        var isUpdated = await _pollService.TogglePublishStatusAsync(id, cancellationToken);
        return isUpdated ? NoContent() : NotFound();
    }
}

