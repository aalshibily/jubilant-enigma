using ProjectFresh.Domain.Constants;
using System.Text.Json;
namespace ProjectFresh.Domain.Models.Joke
{
    public class JokeService : IJokeService
    {
        private readonly HttpClient _httpClient;
        private readonly char[] _chars = { '[', ']' };
        private static readonly JsonSerializerOptions _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public JokeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        private async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                var response = await _httpClient.GetAsync(uri.ToLowerInvariant());
                if (response is not null && response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"JSON Response: {jsonResponse}");

                    return JsonSerializer.Deserialize<T>(jsonResponse.Trim(_chars), _options);
                }
                else
                {
                    // Log error, throw exception, or handle it based on your error handling policy
                    throw new HttpRequestException($"Request to {uri} failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                throw new ApplicationException($"An error occurred when making a GET request to {uri}.", ex);
            }
            
        }

        public Task<Joke> GetJokeById(int jokeId) => GetAsync<Joke>($"/jokes/{jokeId}");
        public Task<Joke> GetOneRandomJoke() => GetAsync<Joke>("/jokes/random");
        public Task<Joke> GetOneRandomJokeByType(JokeType type) => GetAsync<Joke>($"/jokes/{type.ToStringCustom()}/random");
        public Task<IEnumerable<Joke>> GetTenRandomJokes() => GetAsync<IEnumerable<Joke>>("/jokes/random_ten");
        public Task<IEnumerable<Joke>> GetTenRandomJokesByType(JokeType type) => GetAsync<IEnumerable<Joke>>($"/jokes/{type.ToStringCustom()}/ten");
    }
}
