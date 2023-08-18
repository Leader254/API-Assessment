using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API_Consume
{
    public class ApiClient
    {
        private readonly HttpClient _client;

        public ApiClient()
        {
            _client = new HttpClient();
        }

        public async Task<T> GetApiResponseAsync<T>(string apiUrl)
        {
            HttpResponseMessage response = await _client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseBody);
            }
            else
            {
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                return default;
            }
        }
    }
}
