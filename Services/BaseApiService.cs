using ARMauiApp.Configuration;
using ARMauiApp.Models;
using System.Net.Http;
using System.Text.Json;

namespace ARMauiApp.Services
{
    public abstract class BaseApiService : IDisposable
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonOptions;

        protected BaseApiService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiConfig.BaseUrl),
                Timeout = TimeSpan.FromSeconds(ApiConfig.HttpClient.TimeoutSeconds)
            };

            // Add default headers
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "ARMauiApp/1.0");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
                Converters = { 
                    new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
        }

        protected async Task<T?> GetAsync<T>(string endpoint) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);
                
                if (apiResponse?.Success == true)
                {
                    return apiResponse.Data;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in GetAsync<{typeof(T).Name}>: {apiResponse?.Message ?? "Unknown error"}");
                return null;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in GetAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in GetAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
        }

        protected async Task<List<T>> GetListAsync<T>(string endpoint) where T : class
        {
            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<List<T>>>(content, _jsonOptions);
                
                if (apiResponse?.Success == true && apiResponse.Data != null)
                {
                    return apiResponse.Data;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in GetListAsync<{typeof(T).Name}>: {apiResponse?.Message ?? "Unknown error"}");
                return new List<T>();
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in GetListAsync<{typeof(T).Name}>: {ex.Message}");
                return new List<T>();
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in GetListAsync<{typeof(T).Name}>: {ex.Message}");
                return new List<T>();
            }
        }

        protected async Task<T?> PostAsync<T>(string endpoint, object? data = null) where T : class
        {
            try
            {
                StringContent? content = null;
                if (data != null)
                {
                    var json = JsonSerializer.Serialize(data, _jsonOptions);
                    content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseContent, _jsonOptions);
                
                if (apiResponse?.Success == true)
                {
                    return apiResponse.Data;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in PostAsync<{typeof(T).Name}>: {apiResponse?.Message ?? "Unknown error"}");
                return null;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in PostAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in PostAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
        }

        protected async Task<bool> PostAsync(string endpoint, object? data = null)
        {
            try
            {
                StringContent? content = null;
                if (data != null)
                {
                    var json = JsonSerializer.Serialize(data, _jsonOptions);
                    content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.PostAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, _jsonOptions);
                
                if (apiResponse?.Success == true)
                {
                    return true;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in PostAsync: {apiResponse?.Message ?? "Unknown error"}");
                return false;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in PostAsync: {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in PostAsync: {ex.Message}");
                return false;
            }
        }

        protected async Task<T?> PutAsync<T>(string endpoint, object? data = null) where T : class
        {
            try
            {
                StringContent? content = null;
                if (data != null)
                {
                    var json = JsonSerializer.Serialize(data, _jsonOptions);
                    content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                }

                var response = await _httpClient.PutAsync(endpoint, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<T>>(responseContent, _jsonOptions);
                
                if (apiResponse?.Success == true)
                {
                    return apiResponse.Data;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in PutAsync<{typeof(T).Name}>: {apiResponse?.Message ?? "Unknown error"}");
                return null;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in PutAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in PutAsync<{typeof(T).Name}>: {ex.Message}");
                return null;
            }
        }

        protected async Task<bool> DeleteAsync(string endpoint)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(endpoint);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse<object>>(responseContent, _jsonOptions);
                
                if (apiResponse?.Success == true)
                {
                    return true;
                }
                
                System.Diagnostics.Debug.WriteLine($"API Error in DeleteAsync: {apiResponse?.Message ?? "Unknown error"}");
                return false;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"HTTP Error in DeleteAsync: {ex.Message}");
                return false;
            }
            catch (JsonException ex)
            {
                System.Diagnostics.Debug.WriteLine($"JSON Error in DeleteAsync: {ex.Message}");
                return false;
            }
        }

        public virtual void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
