
using SurveyBasket.Api.Entities;
using System.Threading;

namespace SurveyBasket.Api.Services;

public class PollService(ApplicationDbContext context) : IPollService
{
    private readonly ApplicationDbContext _context = context;

    public async Task<IEnumerable<Poll>> GetAllAsync(CancellationToken cancellationToken = default) => 
        await _context.Polls.AsNoTracking().ToListAsync(cancellationToken);


    public async Task<Poll?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _context.Polls.FindAsync(id, cancellationToken);

    public async Task<Poll> AddAsync(Poll poll , CancellationToken cancellationToken = default)
    {

        await _context.AddAsync(poll);
        await _context.SaveChangesAsync(cancellationToken);

        return poll;

    }

    public async Task< bool > UpdateAsync(int id, Poll poll , CancellationToken cancellationToken = default)
    {
        var currentPoll = await GetByIdAsync(id, cancellationToken);

        if (currentPoll is null)
            return false;

        currentPoll.Title = poll.Title;
        currentPoll.Summary = poll.Summary;
        currentPoll.StartsAt = poll.StartsAt;
        currentPoll.EndsAt = poll.EndsAt;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task < bool > DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var currentPoll = await GetByIdAsync(id, cancellationToken);

        if (currentPoll is null)
            return false;

        _context.Remove(currentPoll);
        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<bool > TogglePublishStatusAsync(int id, CancellationToken cancellationToken = default)
    {
        var currentPoll = await GetByIdAsync(id, cancellationToken);

        if (currentPoll is null)
            return false;

        currentPoll.IsPublished = !currentPoll.IsPublished;

        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
    
}
