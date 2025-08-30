using CompanyWeb.Models;
using System.Text.Json;

namespace CompanyWeb.Services
{
    public class PegawaiApiService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _options;

        public PegawaiApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<IEnumerable<PegawaiViewModel>?> GetAllPegawaiAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/pegawai");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<PegawaiViewModel>>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting all pegawai: {ex.Message}");
                return null;
            }
        }

        public async Task<PegawaiViewModel?> GetPegawaiByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pegawai/{id}");
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PegawaiViewModel>(jsonString, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting pegawai by id {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<PegawaiViewModel?> CreatePegawaiAsync(PegawaiViewModel pegawai)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync("api/pegawai", jsonContent);
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<PegawaiViewModel>(responseStream, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating pegawai: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> UpdatePegawaiAsync(PegawaiViewModel pegawai)
        {
            try
            {
                var jsonContent = new StringContent(JsonSerializer.Serialize(pegawai, _options), System.Text.Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"api/pegawai/{pegawai.PegawaiID}", jsonContent);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating pegawai {pegawai.PegawaiID}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeletePegawaiAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/pegawai/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting pegawai {id}: {ex.Message}");
                return false;
            }
        }

        public async Task<IEnumerable<PegawaiViewModel>?> SearchPegawaiAsync(string nama)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/pegawai/search?nama={nama}");
                response.EnsureSuccessStatusCode();
                var responseStream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<IEnumerable<PegawaiViewModel>>(responseStream, _options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching pegawai: {ex.Message}");
                return null;
            }
        }
    }
}
