using CompanyAPI.Models;
using CompanyAPI.ViewModels;

namespace CompanyAPI.Services
{
    public interface IPegawaiService
    {
        Task<IEnumerable<Pegawai>> GetAllAsync();
        Task<Pegawai?> GetByIdAsync(int id);
        Task<Pegawai> CreateAsync(PegawaiDto pegawaiDto);
        Task<bool> UpdateAsync(int id, PegawaiDto pegawaiDto);
        Task<bool> DeleteAsync(int id);
        Task<BatchResult> ProcessBatchAsync(List<PegawaiDto> pegawaiDtos);
    }
}