namespace ProjectFresh.Domain.Clients
{
    public class JokeApiClient
    {
        private readonly HttpClient _httpClient;
        public JokeApiClient(HttpClient httpClient)
        {
            this._httpClient = httpClient;
            this._httpClient.BaseAddress = new Uri("https://official-joke-api.appspot.com");
        }
    }
}
