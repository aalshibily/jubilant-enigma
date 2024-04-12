using Aegis.Core.Domain.Entities;
using Aegis.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Aegis.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Properties>> GetAlertsByState(string state)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/alerts/active?area={state}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var activeAlerts = JsonSerializer.Deserialize<ActiveAlert>(jsonResponse);
                    return activeAlerts.features.Select(f => f.properties);
                }
                else
                {
                    throw new HttpRequestException($"Request to '/alerts/active?area={state}' failed with status code {response.StatusCode}.");
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"An error occurred while making a GET request to '/alerts/active?area={state}'", ex);
            }
        }

    }
}
