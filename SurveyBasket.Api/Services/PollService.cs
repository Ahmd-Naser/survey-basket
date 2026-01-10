
using SurveyBasket.Api.Models;

namespace SurveyBasket.Api.Services;

public class PollService : IPollService
{
    private static readonly List<Poll> _polls = [new() { Id = 1, Title = "poll1", Description = "my first poll" }];


    public IEnumerable<Poll> GetAll() => _polls;
     

    public Poll? GetById(int id)
    {
        var poll = _polls.FirstOrDefault(p => p.Id == id);

        return poll ;
    }
    public Poll Add(Poll poll)
    {
        var newId = _polls.Count + 1;
        poll.Id = newId;
        _polls.Add(poll);
        return poll ;

    }

    public bool Update(int id, Poll poll)
    {
        var currentPoll = GetById(id);

        if (currentPoll is null)
            return false;

        currentPoll.Title = poll.Title; 
        currentPoll.Description = poll.Description;

        return true;
    }

    public bool Delete(int id)
    {
        var currentPoll = GetById(id);

        if (currentPoll is null)
            return false;

        _polls.Remove(currentPoll);
        return true;
    }
}
