using Aegis.Core.Domain.Entities;
using Aegis.Core.Exceptions;
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

        public async Task<IEnumerable<SmallAlert>> GetAlertsByState(string state)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/alerts/active?area={state}");
                
                if(response.StatusCode == System.Net.HttpStatusCode.BadGateway)
                {
                    throw new BadGatewayException($"Request to '/alerts/active?area={state}' failed with status code {response.StatusCode}. API might be down.");
                }
                
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var activeAlerts = JsonSerializer.Deserialize<ActiveAlert>(jsonResponse);
                    var alerts = new List<SmallAlert>();
                    foreach (var alert in activeAlerts.features)
                    {
                        alerts.Add(new SmallAlert(alert.properties));
                    }
                    return alerts;
                }
                else
                {
                    throw new HttpRequestException($"Request to '/alerts/active?area={state}' failed with status code {response.StatusCode}.");
                }
                
            }
            catch (Exception ex)
            {
                if(ex.GetType() == typeof(JsonException))
                {
                    throw new JsonException($"An error occurred while deserializing the response from '/alerts/active?area={state}'", ex);
                }
                
                throw new ApplicationException($"An error occurred while making a GET request to '/alerts/active?area={state}'", ex);
            }
        }

    }
}
