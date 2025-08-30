using CompanyWeb.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CompanyWeb.Services
{
    public class PegawaiApiService
    {
        private readonly HttpClient _httpClient;

        public PegawaiApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<PegawaiViewModel>?> GetAllPegawaiAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PegawaiViewModel>>("api/Pegawai");
        }

        public async Task<PegawaiViewModel?> GetPegawaiByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<PegawaiViewModel>($"api/Pegawai/{id}");
        }

        public async Task<PegawaiViewModel?> CreatePegawaiAsync(PegawaiViewModel pegawai)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Pegawai", pegawai);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<PegawaiViewModel>();
            }
            return null;
        }

        public async Task<bool> UpdatePegawaiAsync(PegawaiViewModel pegawai)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Pegawai/{pegawai.PegawaiID}", pegawai);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePegawaiAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Pegawai/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<IEnumerable<PegawaiViewModel>?> SearchPegawaiAsync(string nama)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<PegawaiViewModel>>($"api/Pegawai/search?nama={nama}");
        }

        public async Task<BatchResultViewModel?> ProcessBatchAsync(List<PegawaiViewModel> pegawaiList)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Pegawai/batch", pegawaiList);
            return await response.Content.ReadFromJsonAsync<BatchResultViewModel>();
        }
    }
}