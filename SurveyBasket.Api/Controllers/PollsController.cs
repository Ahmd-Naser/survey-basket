
using SurveyBasket.Api.Services;

namespace SurveyBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_pollService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var poll = _pollService.GetById(id);

        return poll is null ? NotFound() : Ok(poll);
    }

    [HttpPost("")]
    public IActionResult Add(Poll poll)
    {
        var createdPoll = _pollService.Add(poll);
        return CreatedAtAction(nameof(GetById), new { id = createdPoll.Id }, createdPoll);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id,Poll request)
    {
        var isUpdated = _pollService.Update(id, request);

        return isUpdated ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var isDeleted = _pollService.Delete(id);
        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
}

