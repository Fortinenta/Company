using CompanyWeb.Models;
using System.Text.Json;

namespace CompanyWeb.Services
{
    public class JabatanApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public JabatanApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<JabatanViewModel>?> GetAllJabatanAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/jabatan");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<JabatanViewModel>>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all jabatan: {ex.Message}");
                return null;
            }
        }

        public async Task<JabatanViewModel?> GetJabatanByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/jabatan/{id}");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<JabatanViewModel>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting jabatan by id {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<JabatanViewModel?> CreateJabatanAsync(JabatanViewModel jabatan)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(jabatan, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/jabatan", jsonContent);
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<JabatanViewModel>(responseStream, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating jabatan: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdateJabatanAsync(JabatanViewModel jabatan)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(jabatan, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/jabatan/{jabatan.JabatanID}", jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating jabatan {jabatan.JabatanID}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteJabatanAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/jabatan/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting jabatan {id}: {ex.Message}");
                return false;
            }
        }
    }
}

