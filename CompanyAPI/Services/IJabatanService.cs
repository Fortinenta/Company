using CompanyAPI.ViewModels;

namespace CompanyAPI.Services
{
    public interface IJabatanService
    {
        Task<IEnumerable<JabatanDto>> GetAllJabatanAsync();
        Task<JabatanDto?> GetJabatanByIdAsync(int id);
        Task<JabatanDto> CreateJabatanAsync(JabatanDto jabatanDto);
        Task<bool> UpdateJabatanAsync(int id, JabatanDto jabatanDto);
        Task<bool> DeleteJabatanAsync(int id);
    }
}
