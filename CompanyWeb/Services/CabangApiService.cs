using CompanyWeb.Models;
using System.Text.Json;

namespace CompanyWeb.Services
{
    public class CabangApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public CabangApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<CabangViewModel>?> GetAllCabangAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/cabang");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<CabangViewModel>>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all cabang: {ex.Message}");
                return null;
            }
        }

        public async Task<CabangViewModel?> GetCabangByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/cabang/{id}");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CabangViewModel>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting cabang by id {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<CabangViewModel?> CreateCabangAsync(CabangViewModel cabang)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cabang, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/cabang", jsonContent);
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<CabangViewModel>(responseStream, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating cabang: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateCabangAsync(CabangViewModel cabang)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(cabang, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/cabang/{cabang.CabangID}", jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating cabang {cabang.CabangID}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteCabangAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/cabang/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting cabang {id}: {ex.Message}");
                return false;
            }
        }
    }
}

