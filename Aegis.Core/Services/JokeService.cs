using Aegis.Core.Domain.Entities;
using Aegis.Core.Domain.Enums;
using Aegis.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aegis.Core.Services
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

        public async Task<IEnumerable<Joke>> GetJokeById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/jokes/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var joke = JsonSerializer.Deserialize<Joke>(jsonResponse.Trim(_chars), _options);
                    
                    return [joke];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return [new Joke()]; //default id == 0, UI will handle displaying NotFound/InvalidId error
                }
                else
                {
                    throw new HttpRequestException($"Request to '/jokes/{id}' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/jokes/{id}'", ex);
            }
        }

        public async Task<IEnumerable<Joke>> GetOneByType(JokeType type)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/jokes/{type.GetFriendlyName()}/random");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var joke = JsonSerializer.Deserialize<Joke>(jsonResponse.Trim(_chars), _options);

                    return [joke];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return [new Joke()]; //default id == 0, UI will handle displaying NotFound/InvalidId error
                }
                else
                {
                    throw new HttpRequestException($"Request to '/jokes/{type.GetFriendlyName()}/random' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/jokes/{type.GetFriendlyName()}/random'", ex);
            }
        }

        public async Task<IEnumerable<Joke>> GetOneRandom()
        {
            try
            {
                var response = await _httpClient.GetAsync("/jokes/random");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var joke = JsonSerializer.Deserialize<Joke>(jsonResponse.Trim(_chars), _options);

                    return [joke];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return [new Joke()]; //default id == 0, UI will handle displaying NotFound/InvalidId error
                }
                else
                {
                    throw new HttpRequestException($"Request to '/jokes/random' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/jokes/random'", ex);
            }
        }

        public async Task<IEnumerable<Joke>> GetTenByType(JokeType type)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/jokes/{type.GetFriendlyName()}/ten");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jokes = JsonSerializer.Deserialize<IEnumerable<Joke>>(jsonResponse.Trim(_chars), _options);

                    return jokes;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return [new Joke()]; //default id == 0, UI will handle displaying NotFound/InvalidId error
                }
                else
                {
                    throw new HttpRequestException($"Request to '/jokes/{type.GetFriendlyName()}/ten' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/jokes/{type.GetFriendlyName()}/ten'", ex);
            }
        }

        public async Task<IEnumerable<Joke>> GetTenRandom()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/jokes/ten");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var jokes = JsonSerializer.Deserialize<IEnumerable<Joke>>(jsonResponse.Trim(_chars), _options);

                    return jokes;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return [new Joke()]; //default id == 0, UI will handle displaying NotFound/InvalidId error
                }
                else
                {
                    throw new HttpRequestException($"Request to '/jokes/ten' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/jokes/ten'", ex);
            }
        }
    }
}
