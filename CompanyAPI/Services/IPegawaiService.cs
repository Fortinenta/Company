using CompanyAPI.ViewModels;

namespace CompanyAPI.Services
{
    public interface IPegawaiService
    {
        Task<IEnumerable<PegawaiDto>> GetAllPegawaiAsync();
        Task<PegawaiDto?> GetPegawaiByIdAsync(int id);
        Task<PegawaiDto> CreatePegawaiAsync(PegawaiDto pegawaiDto);
        Task<bool> UpdatePegawaiAsync(int id, PegawaiDto pegawaiDto);
        Task<bool> DeletePegawaiAsync(int id);
        Task<IEnumerable<PegawaiDto>> SearchPegawaiAsync(string nama);
    }
}
