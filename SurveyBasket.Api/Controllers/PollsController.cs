using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet("")]
    public async Task< IActionResult > GetAll(CancellationToken cancellationToken = default)
    {
        return Ok(await _pollService.GetAllAsync(cancellationToken));
    }

    [HttpGet("current")]
    public async Task<IActionResult> GetCurrent(CancellationToken cancellationToken = default)
    {
        return Ok(await _pollService.GetCurrentAsync(cancellationToken));
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id , CancellationToken cancellationToken = default)
    {
        var result = await _pollService.GetByIdAsync(id, cancellationToken);

        return result.IsSuccess 
            ? Ok(result.Value) 
            : result.ToProblem();

    }

    [HttpPost("")]
    public async Task<IActionResult> Add([FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.AddAsync(request , cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value.Adapt<PollResponse>())
            : result.ToProblem();

         
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PollRequest request, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.UpdateAsync(id, request, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProblem();

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.DeleteAsync(id, cancellationToken);

        return result.IsSuccess 
            ? NoContent() 
            : result.ToProblem();
    }

    [HttpPut("{id}/togglePublish")]
    public async Task<IActionResult> TogglePublish([FromRoute] int id, CancellationToken cancellationToken = default)
    {
        var result = await _pollService.TogglePublishStatusAsync(id, cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : result.ToProblem();
    }
}

