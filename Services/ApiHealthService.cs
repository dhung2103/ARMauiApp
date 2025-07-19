using ARMauiApp.Configuration;
using System.Net.Http;

namespace ARMauiApp.Services
{
    public class ApiHealthService : BaseApiService
    {
        public async Task<bool> IsApiHealthyAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("health");
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TestCategoryEndpointAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiConfig.Endpoints.Categories);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> TestProductEndpointAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(ApiConfig.Endpoints.Products);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public async Task<string> GetApiResponseAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                return $"Error: {response.StatusCode} - {response.ReasonPhrase}";
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }
    }
}
