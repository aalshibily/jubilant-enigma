using ProjectFresh.Domain.Constants;

namespace ProjectFresh.Domain.Models.Joke
{
    public interface IJokeService
    {
        Task<Joke> GetJokeById(int JokeId);
        Task<Joke> GetOneRandomJoke();
        Task<Joke> GetOneRandomJokeByType(JokeType type);
        Task<IEnumerable<Joke>> GetTenRandomJokes();
        Task<IEnumerable<Joke>> GetTenRandomJokesByType(JokeType type);
    }
}
