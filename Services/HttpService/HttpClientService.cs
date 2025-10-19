using BudgetApproved.Models; 
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BudgetApproved.Services
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        
        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public void SetBaseAddress(string baseAddress)
        {
            _httpClient.BaseAddress = new Uri(baseAddress);
        }

        public async Task<IEnumerable<T>> GetAsync<T>(string endpoint)
        {
            var response = await _httpClient.GetAsync(endpoint);
            response.EnsureSuccessStatusCode(); 
            
            return await response.Content.ReadFromJsonAsync<IEnumerable<T>>() ?? new List<T>();
        }

        public async Task<T> PostAsync<T>(string endpoint, T data)
        {
            var response = await _httpClient.PostAsJsonAsync(endpoint, data);
            response.EnsureSuccessStatusCode(); 
            
            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
